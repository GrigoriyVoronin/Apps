import { IDataError } from './IDataError';
import type { IErrorInfo } from './types';
import { HttpCode } from '../processors/constants';
import { DataErrorType } from './types';

export class DataError<T = IErrorInfo> extends IDataError<T> {
  public readonly name: string = `${DataErrorType.Base}`;
  public readonly status: number = HttpCode.Unknown;
  public readonly caption?: string;
  public readonly message: string;
  public readonly adapterErrors: T[];
  public readonly data: object | undefined;
  public readonly serializerErrors: T[];

  constructor(message: string, remoteErrors: T[], data?: any) {
    super(message);

    this.message = message;
    this.adapterErrors = remoteErrors;
    this.data = data;
    this.serializerErrors = [];
  }

  public addDeserializedErrors(errors: T[]) {
    this.serializerErrors.push(...errors);
  }

  public static isDataError<T>(error?: T | IDataError): error is IDataError {
    return !!error && error instanceof IDataError;
  }

  public static isNotDataError<T>(error: T | IDataError): error is T {
    return !(error instanceof IDataError);
  }
}
