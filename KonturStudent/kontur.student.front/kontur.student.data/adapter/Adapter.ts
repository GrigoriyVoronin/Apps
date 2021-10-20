import { AxiosResponse } from 'axios';
import { inject } from 'kontur.student.di';
import { IModelEndpoint, IModelSettings } from '../models/types';
import { IDataTransport } from '../transport/IDataTransport';
import { IAdapter } from './IAdapter';
import {
  GetRecordOperationType,
  IAnyAdapterRequestOptions,
  IQueryParameters,
  IRequestHeaders,
  OperationType,
} from './types';
import { IResponseProcessor } from '../processors/IResponseProcessor';
import { IRequestUrlBuilder } from '../request/requestUrlBuilder/IRequestUrlBuilder';
import { IDataError } from '../errors/IDataError';

export class Adapter extends IAdapter {
  protected readonly endpoint: string;
  protected readonly transport: IDataTransport;
  protected readonly requestBaseBuilder: IRequestUrlBuilder;
  protected readonly responseProcessor: IResponseProcessor;
  protected readonly modelSettings: IModelSettings;

  constructor(
    @inject(IModelEndpoint) endpoint: string,
    @inject(IModelSettings) modelSettings: IModelSettings,
    @inject(IDataTransport) transport: IDataTransport,
    @inject(IRequestUrlBuilder) requestBaseBuilder: IRequestUrlBuilder,
    @inject(IResponseProcessor) responseProcessor: IResponseProcessor
  ) {
    super();
    this.requestBaseBuilder = requestBaseBuilder;
    this.responseProcessor = responseProcessor;
    this.endpoint = endpoint;
    this.transport = transport;
    this.modelSettings = modelSettings;
  }

  public generateId(payload: any): string {
    return ''; // TODO: add uuid for guid generation
  }

  public async createRecord<R>(payload: any): Promise<R | IDataError> {
    const url = this.buildUrl(OperationType.createRecord, undefined, payload);
    const headers = this.getHeaders(OperationType.createRecord);
    const params = this.getQueryParameters(OperationType.createRecord);

    try {
      const result = await this.transport.post(url, payload, { params, headers });
      return this.processResult(result, OperationType.createRecord);
    } catch (error) {
      return this.processResult(error, OperationType.createRecord);
    }
  }

  public async findRecord<R>(
    id: string,
    options?: IAnyAdapterRequestOptions,
    type: GetRecordOperationType = OperationType.findRecord
  ): Promise<R | IDataError> {
    const url = this.buildUrl(type, id);
    const headers = this.getHeaders(type, id);
    const params = this.getQueryParameters(type, id);

    try {
      const result = await this.transport.get(url, { params, headers });
      return this.processResult(result, type);
    } catch (error) {
      return this.processResult(error, type);
    }
  }

  public async findAll<R>(): Promise<R | IDataError> {
    const url = this.buildUrl(OperationType.findAll);
    const headers = this.getHeaders(OperationType.findAll);
    const params = this.getQueryParameters(OperationType.findAll, '');

    try {
      const result = await this.transport.get(url, { params, headers });
      return this.processResult(result, OperationType.findAll);
    } catch (error) {
      return this.processResult(error, OperationType.findAll);
    }
  }

  public async deleteRecord(id: string): Promise<void | IDataError> {
    const url = this.buildUrl(OperationType.deleteRecord, id);
    const headers = this.getHeaders(OperationType.deleteRecord, id);
    const params = this.getQueryParameters(OperationType.deleteRecord, id);

    try {
      const result = await this.transport.delete(url, { params, headers });
      return this.processResult(result, OperationType.deleteRecord);
    } catch (error) {
      return this.processResult(error, OperationType.deleteRecord);
    }
  }

  public async updateRecord<R>(payload: any, id?: string): Promise<R | IDataError> {
    const url = this.buildUrl(OperationType.updateRecord, id);
    const params = this.getQueryParameters(OperationType.updateRecord);
    const headers = this.getHeaders(OperationType.updateRecord);

    try {
      const result = await this.transport.put(url, payload, { params, headers });
      return this.processResult(result, OperationType.updateRecord);
    } catch (error) {
      return this.processResult(error, OperationType.updateRecord);
    }
  }

  public buildUrl(operation: OperationType, id?: string, payload?: any): string {
    const base = this.getUrlBase();
    const namespace = this.getNamespace(operation, id);
    const endpoint = this.getEndpoint(operation, id, payload);
    const operationPostfix = this.getOperationPostfix(operation);
    return [base, namespace, endpoint, id, operationPostfix]
      .filter(Boolean)
      .join('/')
      .replace(/([^:]\/)(\/+)/g, '$1');
  }

  public getUrlBase() {
    return this.requestBaseBuilder.getUrlBase();
  }

  public getNamespace(operation: OperationType, id?: string) {
    return this.requestBaseBuilder.getNamespace(operation, id);
  }

  public getEndpoint(operation: OperationType, id?: string, payload?: any) {
    return this.endpoint;
  }

  public getOperationPostfix(operation: OperationType): string {
    const operationPostfixes = this.modelSettings.operationPostfixes;

    if (!operationPostfixes) {
      return '';
    }
    switch (operation) {
      case OperationType.locate: {
        return operationPostfixes.locate;
      }
      case OperationType.getCount: {
        return operationPostfixes.getCount;
      }
      case OperationType.createRecords: {
        return operationPostfixes.createMany;
      }
      case OperationType.restoreRecord: {
        return operationPostfixes.restore;
      }
      default: {
        return '';
      }
    }
  }

  protected getHeaders(operation: OperationType, id?: string): Nullable<IRequestHeaders> {
    const result: IRequestHeaders = this.requestBaseBuilder.getHeaders(operation, id);
    const customHeaders = this.getCustomHeaders(operation, id);
    if (customHeaders) {
      Object.assign(result, customHeaders);
    }
    return result;
  }

  protected getCustomHeaders(operation: OperationType, id?: string): IRequestHeaders | null {
    return null;
  }

  protected getQueryParameters(
    operation: OperationType,
    id?: string,
    requestParameters?: IQueryParameters
  ): IQueryParameters {
    const params: IQueryParameters = {};
    const customParameters = this.getCustomQueryParameters(operation, id, requestParameters);

    if (customParameters) {
      Object.assign(params, customParameters);
    }

    if (requestParameters) {
      Object.assign(params, requestParameters);
    }

    return params;
  }

  protected getCustomQueryParameters(
    operation: OperationType,
    id?: string,
    params?: IQueryParameters
  ): IQueryParameters | null {
    return null;
  }

  protected processResult<T>(response: AxiosResponse<T>, operationType: OperationType): T | IDataError {
    return this.responseProcessor.process(response);
  }
}
