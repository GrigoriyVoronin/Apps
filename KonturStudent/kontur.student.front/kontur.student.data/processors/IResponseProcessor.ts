import { AxiosError, AxiosResponse } from 'axios';
import { injectable } from 'kontur.student.di';
import { HttpCode, RequestMethod } from './constants';
import { IDataError } from '../errors/IDataError';

@injectable()
export abstract class IResponseProcessor {
  public abstract process<T>(response: AxiosResponse<T> | AxiosError<T> | Error): T | IDataError;
  public abstract processSuccess<T>(response: AxiosResponse<T>, logBreadcrumb?: boolean): T | IDataError;
  public abstract processError<T>(response: AxiosResponse<T> | AxiosError<T>): Error;
  protected abstract shouldContainData(method: RequestMethod, statusCode: HttpCode): boolean;
}
