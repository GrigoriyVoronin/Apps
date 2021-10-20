import { types, IStateTreeNode, IAnyModelType, IModelType, ISimpleType, getRoot, getSnapshot } from 'mobx-state-tree';
import { IRepositoryState } from '../repository/RepositoryState';
import { IModelMeta, ModelMeta } from './ModelMeta';

export interface IModelState {
  $meta: IModelMeta;
}

export interface IModelActions {
  save(): Promise<IModel>;
  reload(): Promise<IModel>;
  delete(): MaybePromise<void>;
  rollback(): void;
  getSnapshot(): IModelSnapshot;
}

export interface TModel extends IModelType<{ id: ISimpleType<string> }, IModelState & IModelActions> {}

export interface IModel extends IStateTreeNode<IAnyModelType> {
  id: string;
  $meta: IModelMeta;
  getSnapshot(): IModelSnapshot;
  save(): Promise<IModel>;
  reload(): Promise<IModel>;
  delete(): MaybePromise<void>;
  rollback(): void;
}

export interface IModelSnapshot {
  id: string;
}

export interface IModelCreate {
  id: string;
}

export const Model = types
  .model({
    id: types.identifier,
  })
  .volatile<{ $meta: IModelMeta }>((self) => ({
    $meta: ModelMeta.create({
      id: self.id,
    }),
  }))
  .actions((self) => ({
    save(): Promise<IModel> {
      return getRoot<IRepositoryState>(self).saveRecord((self as unknown) as IModel);
    },
    reload(): Promise<IModel> {
      return getRoot<IRepositoryState>(self).reloadRecord((self as unknown) as IModel);
    },
    delete(): MaybePromise<void> {
      return getRoot<IRepositoryState>(self).deleteRecord((self as unknown) as IModel);
    },
    rollback(): void {
      return getRoot<IRepositoryState>(self).rollbackItem((self as unknown) as IModel);
    },
    getSnapshot(): IModelSnapshot {
      return getSnapshot(self);
    },
  }));
