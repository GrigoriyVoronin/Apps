import { inject, LazyServiceIdentifer } from 'kontur.student.di';
import { IRouterService, TRouterService } from 'kontur.student.routing';
import { IServiceFactory, TServiceFactory } from 'kontur.student.services';
import { transaction } from 'mobx';
import { SnapshotIn, SnapshotOut } from 'mobx-state-tree';
import { IAdapter } from '../adapter/IAdapter';
import { GetRecordOperationType, IAdapterRequestOptions, OperationType } from '../adapter/types';
import { TRepositoryFactory } from '../container/RepositoryFactory';
import { DataError } from '../errors/DataError';
import { IModel, IModelCreate, IModelSnapshot } from '../models/Model';
import { IModelSettings, TModel } from '../models/types';
import { ISerializer } from '../serializer/ISerializer';
import { IRepository } from './IRepository';
import { CreateRepositoryEnvironment, CreateRepositoryState, IRepositoryState } from './RepositoryState';
import {
  IRepositoryEnvironment,
  IRepositoryEnvironmentFactories,
  IRepositoryEnvironmentServices,
  IRepositoryFactory,
} from './types';

export class Repository<
  MT extends TModel,
  M extends IModel = IModel,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
> extends IRepository<MT, M, S, C> {
  public readonly modelType: MT;
  public readonly adapter: IAdapter;
  public readonly serializer: ISerializer<MT, M, S, C>;

  protected readonly state: IRepositoryState;
  protected readonly environment: IRepositoryEnvironment<MT, M, S, C>;

  constructor(
    @inject(TModel) modelType: MT,
    @inject(IModelSettings) settings: IModelSettings,
    @inject(IAdapter) adapter: IAdapter,
    @inject(ISerializer) serializer: ISerializer<MT, M, S, C>,
    @inject(new LazyServiceIdentifer(() => IRepositoryFactory)) repositoryFor: TRepositoryFactory,
    @inject(new LazyServiceIdentifer(() => IServiceFactory)) serviceFor: TServiceFactory,
    @inject(new LazyServiceIdentifer(() => IRouterService)) routerService: TRouterService
  ) {
    super();
    this.modelType = modelType;
    this.adapter = adapter;
    this.serializer = serializer;

    const envFactories: IRepositoryEnvironmentFactories = {
      repositoryFor: repositoryFor,
      serviceFor: serviceFor,
    };
    const envServices: IRepositoryEnvironmentServices = {
      // TODO: add ApiService
      routerService,
    };

    this.environment = CreateRepositoryEnvironment(this, this.modelType, envFactories, envServices);
    this.state = CreateRepositoryState(this.modelType, this.environment);
  }

  public create(snapshot: Override<C, { id?: string }>): M {
    if (!snapshot.id) {
      snapshot.id = this.adapter.generateId();
    }

    if (this.state.hasItem(snapshot.id)) {
      throw new Error(`Trying to .create() already existing model with id=${snapshot.id}`);
    }

    return this.putItem(snapshot as C, true, false);
  }

  public createFromPayload<CA = Partial<C>>(payload: CA) {
    const snapshot = this.serializer.deserializeSingle(payload);
    return this.create(snapshot);
  }

  public async createRecord<CA = C>(snapshot: Override<CA, { id?: string }>): Promise<M> {
    const responsePayload = await this.adapter.createRecord(snapshot);
    if (DataError.isDataError(responsePayload)) {
      throw responsePayload;
    }

    return this.putItem(this.serializer.deserializeSingle(responsePayload), false, false);
  }

  public async createRecordFromPayload<CA = Partial<C>>(payload: CA): Promise<M> {
    const snapshot = this.serializer.deserializeSingle(payload);
    return this.createRecord(snapshot);
  }

  public createDetached(snapshot: Override<C, { id?: string }>): M {
    if (!snapshot.id) {
      snapshot.id = this.adapter.generateId();
    }
    return this.modelType.create(snapshot as C, this.environment) as M;
  }

  public createDetachedFromPayload<CA = Partial<C>>(payload: CA): M {
    const snapshot = this.serializer.deserializeSingle(payload);
    return this.createDetached(snapshot);
  }

  public push(snapshot: C): M {
    return this.putItem(snapshot, false, false);
  }

  public pushPayload(payload: S & any): M {
    const serialized = this.serializer.deserializeSingle(payload);
    return this.push(serialized);
  }

  public hasRecord(id: string) {
    return this.state.hasItem(id);
  }

  public peekRecord(id: string): M {
    if (!this.state.hasItem(id)) {
      throw Error(`Couldn't peekRecord(${this.modelType.name}.id=${id}). Use .hasRecord() or .peekRecordSafe()`);
    }
    return this.state.getItem<M>(id);
  }

  public peekRecordSafe(id: string): M | undefined {
    return this.state.getItem<M>(id);
  }

  public peekAll(): M[] {
    return this.state.items as M[];
  }

  public async findRecord(id: string, options: IAdapterRequestOptions<M> = {}): Promise<M> {
    return this.findRecordInternal(id, OperationType.findRecord, options);
  }

  private async findRecordInternal(
    id: string,
    operationType: OperationType,
    options: IAdapterRequestOptions<M> = {}
  ): Promise<M> {
    const findRecordPromise = this.getRecord(id, operationType, options);

    try {
      const model = await findRecordPromise;
      return model;
    } catch (e) {
      throw e;
    }
  }

  private async getRecord(id: string, type: OperationType, options: IAdapterRequestOptions<M>) {
    let record = this.peekRecordSafe(id);
    const hadRecord = !!record;
    const performLoad = record && (record.$meta.isNew || record.$meta.isLoading);

    if (!record || performLoad) {
      const responsePayload = await this.adapter.findRecord(id, options);
      if (DataError.isDataError(responsePayload)) {
        throw responsePayload;
      }

      this.isConsistentId(id, responsePayload);
      const snapshot = this.serializer.deserializeSingle(responsePayload);
      record = this.putItem(snapshot, false, false);
    }

    if (hadRecord && !performLoad) {
      const reloadOption = options.shouldReload;
      const doReload = !!reloadOption;
      if (doReload || type === OperationType.reloadRecord) {
        record = await this.reloadRecordInternal(record, OperationType.reloadRecord);
      } else {
        const bgReloadOption = options.shouldBackgroundReload;
        const doBgReload = !!bgReloadOption;
        if (doBgReload || type === OperationType.reloadRecordBackground) {
          this.reloadRecordInternal(record, OperationType.reloadRecordBackground);
        }
      }
    }

    return record;
  }

  public async findAll(options: IAdapterRequestOptions<M> = {}): Promise<M[]> {
    const findAllPromise = this.findAllInternal(options);

    try {
      const models = await findAllPromise;
      return models;
    } catch (e) {
      throw e;
    }
  }

  private async findAllInternal(options: IAdapterRequestOptions<M>) {
    const records = this.peekAll();
    const found = records.length > 0;
    const reloadOption = options.shouldReload;
    const shouldReload = !!reloadOption;

    if (!found || shouldReload) {
      await this.getAllRecords(options);
    }

    const bgReloadOption = options.shouldBackgroundReload;
    const shouldBackgroundReload = !!bgReloadOption;
    if (found && !shouldReload && shouldBackgroundReload) {
      this.getAllRecords();
    }

    return records;
  }

  private async getAllRecords(options: IAdapterRequestOptions<M> = {}): Promise<void> {
    const state = this.state;
    const isFirstLoad = this.peekAll().length === 0;
    if (isFirstLoad) {
      state.$meta.setIsLoading(true);
    } else {
      state.$meta.setIsReloading(true);
      state.$meta.setLastOffset(undefined);
      transaction(() => {
        state.metasMap.forEach(($meta) => $meta.setIsReloading(true));
      });
    }

    const responsePayload = await this.adapter.findAll();
    if (DataError.isDataError(responsePayload)) {
      throw responsePayload;
    }

    const snapshots = this.serializer.deserializeMany(responsePayload);

    this.replaceItems(snapshots);

    transaction(() => {
      state.$meta.setIsLoading(false);
      state.$meta.setIsReloading(false);
    });
  }

  public async reloadRecord(item: M): Promise<M> {
    return await this.findRecordInternal(item.id, OperationType.reloadRecord, {});
  }

  private async reloadRecordInternal(item: M, type: GetRecordOperationType): Promise<M> {
    try {
      const id = item.id;
      item.$meta.setIsReloading(true);
      const responsePayload = await this.adapter.findRecord(id, undefined, type);
      if (DataError.isDataError(responsePayload)) {
        throw responsePayload;
      }
      this.isConsistentId(id, responsePayload);
      const snapshot = this.serializer.deserializeSingle(responsePayload);
      this.setItem(snapshot, false, false);
      return item;
    } catch (e) {
      item.$meta.setIsReloading(false);
      throw e;
    }
  }

  public async deleteRecord(item: M): Promise<void> {
    const $meta = item.$meta;
    const snapshot = this.serializer.serializeSingle(item);
    const id = snapshot.id;
    try {
      $meta.setIsDeleting(true);
      const responsePayload = await this.adapter.deleteRecord(id);
      if (responsePayload && DataError.isDataError(responsePayload)) {
        throw responsePayload;
      }
      this.deleteItem(item);
    } catch (e) {
      $meta.setIsDeleting(false);
      throw e;
    }
  }

  public async saveRecord(model: M, id?: string): Promise<M> {
    model.$meta.setIsSaving(true);
    const savedModel = await this.saveRecordFull(model, id);
    savedModel.$meta.setIsSaving(false);
    return savedModel;
  }

  protected setItem(snapshot: C, isNew: boolean, isLoading: boolean): void {
    const id = snapshot.id;
    const state = this.state;

    if (state.hasItem(id)) {
      transaction(() => state.updateItem(snapshot));
    } else {
      const metaSnapshot = {
        id,
        isNew,
        isLoading,
        isReloading: false,
        isSaving: false,
        isUpdating: false,
        isDeleting: false,
        isDeleted: false,
        didFirstEdit: false,
      };
      transaction(() => state.addItem(snapshot, metaSnapshot));
    }
  }

  protected putItem(snapshot: C, isNew: boolean, isLoading: boolean): M {
    this.setItem(snapshot, isNew, isLoading);
    return this.peekRecord(snapshot.id);
  }

  protected replaceItems(snapshots: C[]) {
    transaction(() => {
      const existingItems = new Map(this.state.itemsMap) as Map<string, M>;
      snapshots.forEach((snapshot) => {
        this.putItem(snapshot, false, false);
        existingItems.delete(snapshot.id);
      });

      existingItems.forEach((item) => {
        this.deleteItem(item);
      });
    });
  }

  public deleteItem(item: M): void {
    this.state.deleteItem(item);
  }

  public rollbackItem(item: M): M {
    const id = item.id;
    const state = this.state;
    const snapshot = state.snapshotsMap.get(id) as C;
    state.updateItem(snapshot, true);

    return item;
  }

  protected async saveRecordFull(model: M, id?: string): Promise<M> {
    const payload = this.serializer.serializeSingle(model);
    const isNew = model.$meta.isNew;
    const responsePayload = isNew
      ? await this.adapter.createRecord(payload)
      : await this.adapter.updateRecord(payload, id);
    if (DataError.isDataError(responsePayload)) {
      throw responsePayload;
    }
    const snapshot = this.serializer.deserializeSingle(responsePayload);
    return this.putItem(snapshot, false, false);
  }

  protected isConsistentId(id: string, payload: any): void | never {
    const incomingId = payload.id || this.serializer.extractId(payload);

    if (id !== incomingId) {
      throw new Error(`Id mismatch: requested ${id}, but got ${incomingId}`);
    }
  }

  public isLoading(): boolean {
    return this.state.$meta.isLoading;
  }

  public isReloading(): boolean {
    return this.state.$meta.isReloading;
  }

  public clean() {
    transaction(() => {
      this.state.clean();
    });
  }

  public toString() {
    return `Repository(${this.modelType.name})`;
  }
}
