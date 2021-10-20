import { IModelType, ISimpleType } from 'mobx-state-tree';
import { IModelActions, IModelState } from './Model';

export interface TModel extends IModelType<{ id: ISimpleType<string> }, IModelState & IModelActions> {}
export abstract class TModel {}

export const IModelEndpoint = Symbol.for('__$DATA_MODEL_ENDPOINT__');
export abstract class IModelSettings {
  abstract shouldReloadRecord?: boolean;
  abstract shouldBackgroundReloadRecord?: boolean;
  abstract shouldReloadAll?: boolean;
  abstract shouldBackgroundReloadAll?: boolean;
  abstract shouldLoadLink?: boolean;
  abstract operationPostfixes?: IModelOperationPostfixesSettings;
}
export interface IModelOperationPostfixesSettings {
  locate: string;
  getCount: string;
  createMany: string;
  restore: string;
}
