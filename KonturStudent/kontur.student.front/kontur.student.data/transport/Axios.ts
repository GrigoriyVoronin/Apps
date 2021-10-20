import axios, { AxiosError, AxiosResponse } from 'axios';

import { injectArguments } from 'kontur.student.di';
import { IQueryParametersProcessor } from '../request/queryParametersProcessor/IQueryParametersProcessor';

export const AxiosTransport = axios.create({
  headers: {
    common: {},
  },
  validateStatus: () => true,
  paramsSerializer: (params) => {
    return injectArguments([IQueryParametersProcessor], (processor: IQueryParametersProcessor) => (params) => {
      return processor.stringify(params);
    })(params);
  },
});

export function isAxiosResponse<T>(response: AxiosResponse<T> | AxiosError<T> | Error): response is AxiosResponse<T> {
  return response.hasOwnProperty('status');
}

export function isAxiosError<T>(response: Error | AxiosError<T>): response is AxiosError<T> {
  return (response as AxiosError<T>).isAxiosError === true;
}
