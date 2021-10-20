import { Instance, SnapshotIn, SnapshotOut } from 'mobx-state-tree';
import { IModel, IModelCreate, IModelSnapshot, TModel } from '../models/Model';
import { ISerializer } from './ISerializer';

export abstract class TSerializer {}
export interface TSerializer<
  MT extends TModel = TModel,
  M extends IModel = Instance<MT>,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
> {
  new (modelType: MT): ISerializer<MT, M, S, C>;
}
