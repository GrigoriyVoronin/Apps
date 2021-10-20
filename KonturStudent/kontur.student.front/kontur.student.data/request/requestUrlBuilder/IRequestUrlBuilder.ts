import { injectable } from 'kontur.student.di';

@injectable()
export abstract class IRequestUrlBuilder {
  public readonly protocol?: Nullable<string>;
  public readonly hostname?: Nullable<string>;
  public readonly port?: Nullable<number>;
  public readonly namespace?: Nullable<string>;

  public abstract getUrlBase(): string;
  public abstract getHeaders(operation: OperationType, id?: string): IRequestHeaders;
  public abstract getNamespace(operation: OperationType, id?: string): this['namespace'];
  protected abstract getProtocolPrefix(): string;
  protected abstract getHostname(): string;
  protected abstract getPortSuffix(protocolPrefix: string): string;
}
export type IRequestHeaders = Record<string, string | undefined>;

export abstract class IRequestBaseBuilderSettings {
  abstract readonly protocol?: Nullable<string>;
  abstract readonly hostname?: Nullable<string>;
  abstract readonly port?: Nullable<number>;
  abstract readonly namespace?: Nullable<string>;
}
export enum OperationType {
  unknown = 'unknown',
  createRecord = 'createRecord',
  createRecords = 'createRecords',
  findRecord = 'findRecord',
  reloadRecord = 'reloadRecord',
  reloadRecordBackground = 'reloadRecordBackground',
  findLink = 'findLink',
  queryRecord = 'queryRecord',
  updateRecord = 'updateRecord',
  patchRecord = 'patchRecord',
  deleteRecord = 'deleteRecord',
  findAll = 'findAll',
  query = 'query',
  fetchNext = 'fetchNext',
  locate = 'locate',
  getCount = 'getCount',
  restoreRecord = 'restoreRecord',
}
