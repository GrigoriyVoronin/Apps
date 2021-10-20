import { IReactionDisposer, observable, reaction } from 'mobx';
import { cast, flow, getEnv, Instance, SnapshotIn, SnapshotOut, types } from 'mobx-state-tree';
import { IModel, IModelCreate, IModelSnapshot, Model } from '../models/Model';
import { IModelMetaSnapshot, ModelMeta } from '../models/ModelMeta';
import { TModel } from '../models/types';
import { IAnyRepository, IRepository } from './IRepository';
import { RepositoryStateMeta } from './RepositoryStateMeta';
import { IRepositoryEnvironment, IRepositoryEnvironmentFactories, IRepositoryEnvironmentServices } from './types';

const RepositoryState = types
  .model('RepositoryState', {
    metasMap: types.map(ModelMeta),
    itemsMap: types.map(Model),
    snapshotsMap: types.map(types.frozen()),
  })
  .extend((self) => {
    let reactionDisposer: Nullable<IReactionDisposer> = null;
    const items = observable.array();
    const $meta = RepositoryStateMeta.create();
    const env = getEnv<IRepositoryEnvironment>(self);
    const modelType = env.modelType;
    const repositoryInstance = env.repository as IAnyRepository;
    return {
      state: { items, $meta, modelType, repositoryInstance },
      actions: {
        afterCreate() {
          reactionDisposer = reaction(
            () => self.itemsMap.values(),
            (itemsIterable) => {
              items.replace(Array.from(itemsIterable));
            }
          );
        },
        beforeDestroy() {
          if (reactionDisposer) {
            reactionDisposer();
          }
        },
      },
    };
  })
  .views((self) => ({
    hasItem(id: string): boolean {
      // NOTE: its performance-wise faster to lookup snapshots, but we could have isNew item in itemsMap, so fallback
      return self.snapshotsMap.has(id) || self.itemsMap.has(id);
    },
    getItem<M extends IModel>(id: string): M {
      return self.itemsMap.get(id) as M;
    },
  }))
  .actions((self) => ({
    addItem<C extends IModelCreate, M extends IModelMetaSnapshot>(snapshot: C, meta: M): void {
      if (typeof meta.id !== 'string') {
        meta.id = `${meta.id}`;
      }

      const id = snapshot.id;

      self.metasMap.set(id, meta);
      self.itemsMap.set(id, snapshot);
      self.snapshotsMap.set(id, snapshot);
    },
    updateItem<C extends IModelCreate, M extends IModel>(snapshot: C, forceUpdate?: boolean): M {
      const id = snapshot.id;

      let shouldUpdate = false;
      if (!forceUpdate) {
        const existingSnapshot = self.snapshotsMap.get(id);
        if (!existingSnapshot) {
          throw new Error(`Trying to update non-existing item with id=${id} (no snapshot)`);
        }
      } else {
        shouldUpdate = true;
      }

      const meta = self.metasMap.get(id);
      if (!meta) {
        throw new Error(`Trying to update non-existing item with id=${id} (no meta)`);
      }

      if (shouldUpdate) {
        meta.setIsUpdating(true);
        self.itemsMap.set(id, snapshot);
        self.snapshotsMap.set(id, snapshot);
      }

      meta.reset();

      return self.itemsMap.get(id) as M;
    },
    rollbackItem<M extends IModel>(item: M): void {
      self.repositoryInstance.rollbackItem(item);
    },
    deleteItem<M extends IModel>(item: M): void {
      const id = item.id;
      item.$meta.reset();
      item.$meta.setIsDeleted(true);

      self.itemsMap.delete(id);
      self.metasMap.delete(id);
      self.snapshotsMap.delete(id);
    },
    clean() {
      self.snapshotsMap = cast({});
      self.itemsMap = cast({});
      self.metasMap = cast({});
      self.$meta = RepositoryStateMeta.create();
    },
  }))
  .actions((self) => ({
    saveRecord: flow(function* <M extends IModel>(item: M) {
      return yield self.repositoryInstance.saveRecord(item);
    }),
    // TODO: find options, pass to store, take into account
    reloadRecord: flow(function* <M extends IModel>(item: M) {
      return yield self.repositoryInstance.reloadRecord(item);
    }),
    deleteRecord: flow(function* <M extends IModel>(item: M) {
      return yield self.repositoryInstance.deleteRecord(item);
    }),
  }));

type TRepositoryState = typeof RepositoryState;

export interface IRepositoryState extends Instance<TRepositoryState> {}

export function CreateRepositoryEnvironment<
  MT extends TModel,
  M extends IModel = Instance<MT>,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
>(
  repository: IRepository<MT, M, S, C>,
  modelType: MT,
  factories: IRepositoryEnvironmentFactories,
  services: IRepositoryEnvironmentServices
): IRepositoryEnvironment<MT, M, S, C> {
  return {
    modelType,
    repository,
    factories,
    services,
  };
}

export function CreateRepositoryState<
  MT extends TModel,
  M extends IModel = Instance<MT>,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
>(modelType: MT, environment: IRepositoryEnvironment<MT, M, S, C>): IRepositoryState {
  const items = types.model(modelType.name.replace('Model', 'Repository'), {
    itemsMap: types.map(modelType),
    snapshotsMap: types.map(types.frozen<MT>()),
  });

  const name = `${modelType.name}Repository`;
  const state = types
    .compose(name, RepositoryState, items)
    .create({ metasMap: {}, itemsMap: {}, snapshotsMap: {} }, environment);

  return state;
}
