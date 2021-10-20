import { IRouterService } from 'kontur.student.routing/IRouterService';
import { TServiceFactory } from 'kontur.student.services';
import { Instance, SnapshotIn, SnapshotOut } from 'mobx-state-tree';
import { TRepositoryFactory } from '../container/RepositoryFactory';
import { IModel, IModelCreate, IModelSnapshot } from '../models/Model';
import { TModel } from '../models/types';
import { IRepository } from './IRepository';

export abstract class IRepositoryEnvironment<
  MT extends TModel = TModel,
  M extends IModel = Instance<MT>,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
> {
  abstract repository: IRepository<MT, M, S, C>;
  abstract modelType: MT;
  abstract factories: IRepositoryEnvironmentFactories;
  abstract services: IRepositoryEnvironmentServices;
  [key: string]: any;
}

export interface IRepositoryEnvironmentFactories {
  repositoryFor: TRepositoryFactory;
  serviceFor: TServiceFactory;
}

export interface IRepositoryEnvironmentServices {
  routerService: IRouterService;
}

export function IRepositoryFactory<
  MT extends TModel = TModel,
  M extends IModel = Instance<MT>,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
>(modelType: MT): IRepository<MT, M, S, C> {
  throw new Error('IRepositoryFactory is not implemented');
}
