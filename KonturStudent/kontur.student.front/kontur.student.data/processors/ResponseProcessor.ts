import { inject } from 'kontur.student.di';
import { AxiosError, AxiosResponse } from 'axios';
import { HttpCode, RequestMethod } from './constants';
import { IResponseProcessor } from './IResponseProcessor';
import { isAxiosResponse, isSuccessfulResponse } from './helpers';
import { DataErrorType, TDataErrorFactory } from '../errors/types';
import { IDataErrorFactory } from '../errors/dataErrorFactory';
import { IDataError } from '../errors/IDataError';

export class ResponseProcessor extends IResponseProcessor {
  constructor(@inject(IDataErrorFactory) private readonly errorFactory: TDataErrorFactory) {
    super();
  }

  public process<T>(response: AxiosResponse<T> | AxiosError<T> | Error): T | IDataError {
    if (isAxiosResponse(response) && isSuccessfulResponse(response.status)) {
      return this.processSuccess(response);
    }

    return this.processError(response);
  }

  public processSuccess<T>(response: AxiosResponse<T>): T {
    const status = response.status;
    const method = response.config.method?.toUpperCase() as RequestMethod;
    return response.data;
  }

  public processError<T>(response: AxiosResponse<T> | AxiosError<T> | Error): IDataError {
    return this.errorFactory(DataErrorType.BadRequest, 'Ошибка в запросе', []);
  }

  protected shouldContainData(method: RequestMethod, statusCode: HttpCode): boolean {
    if (method === RequestMethod.DELETE || method === RequestMethod.HEAD) {
      return false;
    }

    if (statusCode === HttpCode.NoContent) {
      return false;
    }

    return (method === RequestMethod.GET && statusCode !== HttpCode.NotModified) || true;
  }
}
