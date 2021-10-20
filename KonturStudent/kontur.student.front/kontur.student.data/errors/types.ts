import { IDataError } from './IDataError';
import { IDataErrorFactory } from './dataErrorFactory';

export interface IErrorInfo {
  id?: string;
  status?: string;
  code?: string;
  title?: string;
  detail?: string;
  source?: {
    pointer?: string;
    parameter?: string;
  };
  meta?: any;
}

export enum DataErrorType {
  Base = 'ErrorBase',
  Unknown = 'UnknownError',
  Abort = 'AbortError',
  NetworkError = 'NetworkError',
  BadRequest = 'BadRequestError',
  MethodNotAllowed = 'MethodNotAllowedError',
  Unauthorized = 'UnauthorizedError',
  Forbidden = 'ForbiddenError',
  NotFound = 'NotFoundError',
  GatewayTimeout = 'GatewayTimeout',
  ServiceUnavailable = 'ServiceUnavailable',
  InternalServerError = 'InternalServerError',
  UnexpectedPayload = 'UnexpectedPayload',
}

export class TDataError {}
export interface TDataError {
  new <T>(message: string, remoteErrors: T[], data?: any): IDataError<T>;
}

export function TDataErrorFactory() {}
export type TDataErrorFactory = typeof IDataErrorFactory;
