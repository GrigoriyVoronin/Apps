import { AxiosResponse } from 'axios';
import { injectable } from 'kontur.student.di';
import {
  GetRecordOperationType,
  IAnyAdapterRequestOptions,
  IQueryParameters,
  IRequestHeaders,
  OperationType,
} from './types';
import { IDataError } from '../errors/IDataError';

@injectable()
export abstract class IAdapter {
  public abstract generateId(payload?: any): string;
  public abstract createRecord<R = any>(payload: any): Promise<R | IDataError>;
  public abstract findRecord<R = any>(
    id: string,
    options?: IAnyAdapterRequestOptions,
    type?: GetRecordOperationType
  ): Promise<R | IDataError>;
  public abstract findAll<R = any>(): Promise<R | IDataError>;
  public abstract updateRecord<R = any>(payload: any, id?: string): Promise<R | IDataError>;
  public abstract deleteRecord(id: string): Promise<void | IDataError>;
  public abstract buildUrl(operation: OperationType, id?: string, payload?: any): string;
  public abstract getUrlBase(): string;
  public abstract getNamespace(operation: OperationType, id?: string): string | null | undefined;
  public abstract getEndpoint(operation: OperationType, id?: string, payload?: any): string;
  public abstract getOperationPostfix(operation: OperationType): string;

  protected abstract getCustomHeaders(operation: OperationType, id?: string): IRequestHeaders | null;
  protected abstract getCustomQueryParameters(
    operation: OperationType,
    id?: string,
    params?: IQueryParameters
  ): IQueryParameters | null;

  protected abstract processResult<T>(response: AxiosResponse<T>, operationType: OperationType): T | IDataError;
}
