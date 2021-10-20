import { IModel, IModelSnapshot, IModelCreate } from '../index';
import { SnapshotIn, SnapshotOut, Instance } from 'mobx-state-tree';
import { IAdapter } from '../adapter/IAdapter';
import { ISerializer } from '../serializer/ISerializer';
import { IAdapterRequestOptions } from '../adapter/types';
import { IRepositoryState } from './RepositoryState';
import { TModel } from '../models/types';
import { injectable } from 'kontur.student.di';

export interface IAnyRepository extends IRepository<TModel> {}

@injectable()
export abstract class IRepository<
  MT extends TModel,
  M extends IModel = Instance<MT>,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
> {
  public abstract readonly modelType: MT;
  public abstract readonly adapter: IAdapter;
  public abstract readonly serializer: ISerializer<MT, M, S, C>;

  protected abstract readonly state: IRepositoryState;

  public abstract create(snapshot: Override<C, { id?: string }>): M;

  public abstract createFromPayload<CA = Partial<C>>(payload: CA): M;

  public abstract createRecord<CA = C>(snapshot: Override<CA, { id?: string }>): Promise<M>;

  public abstract createRecordFromPayload<CA = Partial<C>>(payload: CA): Promise<M>;

  public abstract createDetached(snapshot: Override<C, { id?: string }>): M;

  public abstract createDetachedFromPayload<CA = Partial<C>>(payload: CA): M;

  public abstract push(serialized: C): M;

  public abstract pushPayload(payload: S & any): M;

  public abstract hasRecord(id: string): boolean;

  public abstract peekRecord(id: string): M;

  public abstract peekRecordSafe(id: string): M | undefined;

  public abstract peekAll(): M[];

  public abstract findRecord(id: string, options?: IAdapterRequestOptions<M>): Promise<M>;

  public abstract findAll(options?: IAdapterRequestOptions<M>): Promise<M[]>;

  public abstract deleteRecord(item: M): Promise<void>;

  public abstract deleteItem(item: M): void;

  public abstract rollbackItem(item: M): M;

  public abstract saveRecord(model: M, id?: string): Promise<M>;

  public abstract reloadRecord(model: M): Promise<M>;

  public abstract isLoading(): boolean;

  public abstract isReloading(): boolean;

  public abstract clean(): void;
}
