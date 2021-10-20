import { IAnyModelType, SnapshotIn } from 'mobx-state-tree';
import { IAdapter } from './IAdapter';

export type IQueryParameters = object &
  (Record<string, string | number | boolean | undefined | string[] | number[] | boolean[]> | SnapshotIn<IAnyModelType>);
export type IRequestHeaders = Record<string, string | undefined>;

export interface IAnyAdapterRequestOptions {
  shouldReload?: boolean;
  shouldBackgroundReload?: boolean;
}

export interface IAdapterRequestOptions<M> extends IAnyAdapterRequestOptions {}

export abstract class TAdapter {}

export interface TAdapter {
  new (...args: any[]): IAdapter;
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
export type LoadRecordOperationType = OperationType.findRecord | OperationType.queryRecord | OperationType.findLink;

export type ReloadRecordOperationType = OperationType.reloadRecord | OperationType.reloadRecordBackground;
export type GetRecordOperationType = LoadRecordOperationType | ReloadRecordOperationType;
export type SaveRecordOperationType = OperationType.updateRecord | OperationType.patchRecord;

export function isGetOperationType(target: OperationType): target is GetRecordOperationType {
  return (
    target === OperationType.findRecord ||
    target === OperationType.queryRecord ||
    target === OperationType.findLink ||
    target === OperationType.reloadRecord ||
    target === OperationType.reloadRecordBackground
  );
}

export function isSaveOperationType(target: OperationType): target is SaveRecordOperationType {
  return target === OperationType.updateRecord || target === OperationType.patchRecord;
}
