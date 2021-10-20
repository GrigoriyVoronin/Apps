import qs from 'qs';

import { hasCyclicReferences } from './hasCyclicReferences';
import { IQueryParametersProcessor } from './IQueryParametersProcessor';
import { IUrlParamsShape, IObjectQueryParams } from '../types';

export const QS_PARSE_OPTIONS = { allowDots: true };
export const QS_STRINGIFY_OPTIONS = { allowDots: true, arrayFormat: 'repeat' as const };

export class QueryParametersProcessor extends IQueryParametersProcessor {
  static stringify: any;
  constructor() {
    super();
  }
  public encodeParams(stateParams: IObjectQueryParams) {
    // we use `allowDots: true` so we never get arrays or nested
    return (qs.parse(this.stringify(stateParams)) as unknown) as IUrlParamsShape;
  }
  public decodeParams(pathParams: IUrlParamsShape) {
    // we use `arrayFormat: 'repeat'` so we never get string[];
    return (qs.parse(this.stringify(pathParams), QS_PARSE_OPTIONS) as unknown) as IObjectQueryParams;
  }
  public stringify(paramsObject: IObjectQueryParams): string {
    if (hasCyclicReferences(paramsObject)) {
      const message = `QueryParametersProcessor.stringify is called with 'paramsObject' which has cyclic references`;
      const error = new Error(message);
      throw error;
    }

    return qs.stringify(paramsObject, QS_STRINGIFY_OPTIONS);
  }
  public parse(url: string): IObjectQueryParams {
    return qs.parse(url, QS_PARSE_OPTIONS);
  }
}
