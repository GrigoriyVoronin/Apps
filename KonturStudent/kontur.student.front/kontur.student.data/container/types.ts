import { IServiceBinding } from 'kontur.student.services';
import { TAdapter } from '../adapter/types';
import { TModel } from '../models/types';
import { TResponseProcessor } from '../processors/types';
import { IDataTransport } from '../transport/IDataTransport';

export interface IDataLayerSettings {
  singletoScopeBindings: IServiceBinding<any>[];
  transport: IDataTransport;
  model: TModel;
  responseProcessor: TResponseProcessor;
  adapter: TAdapter;
}
