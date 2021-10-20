import { injectable } from 'kontur.student.di';
import { IErrorInfo } from './types';

@injectable()
export abstract class IDataError<T = IErrorInfo> extends Error {
  public abstract readonly status: number = 0;
  public abstract readonly caption?: string;
  public abstract readonly adapterErrors: T[];
  public abstract readonly serializerErrors: T[];
  public abstract readonly data: object | undefined;

  public abstract addDeserializedErrors(errors: T[]): void;
}
