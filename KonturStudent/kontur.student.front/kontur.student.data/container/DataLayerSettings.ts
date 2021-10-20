import { Adapter } from '../adapter/Adapter';
import { Model } from '../models/Model';
import { TModel } from '../models/types';
import { ResponseProcessor } from '../processors/ResponseProcessor';
import { IQueryParametersProcessor } from '../request/queryParametersProcessor/IQueryParametersProcessor';
import { QueryParametersProcessor } from '../request/queryParametersProcessor/QueryParametersProcessor';
import { IRequestUrlBuilder } from '../request/requestUrlBuilder/IRequestUrlBuilder';
import { RequestUrlBuilder } from '../request/requestUrlBuilder/RequestUrlBuilder';

import { AxiosTransport } from '../transport/Axios';
import { IDataLayerSettings } from './types';

export const DataLayerSettings: IDataLayerSettings = {
  singletoScopeBindings: [
    {
      bind: IQueryParametersProcessor,
      to: QueryParametersProcessor,
    },
    {
      bind: IRequestUrlBuilder,
      to: RequestUrlBuilder,
    },
  ],
  transport: AxiosTransport,
  model: Model,
  responseProcessor: ResponseProcessor,
  adapter: Adapter,
};
