import { interfaces } from 'kontur.student.di';
import { DataErrorType, IErrorInfo, TDataError } from './types';
import { IDataError } from './IDataError';

export function IDataErrorFactory<T = IErrorInfo>(
  type: DataErrorType,
  message: string,
  adapterErrors: T[],
  data?: any
): IDataError {
  throw new Error('IDataErrorFactory is not implemented');
}

export const dataErrorFactory: interfaces.FactoryCreator<IDataError> = function dataErrorFactory(context) {
  const container = context.container;

  return function (type: DataErrorType, message: string, adapterErrors: any[], data?: any) {
    const DataError = container.getNamed(TDataError, type);
    return new DataError(message, adapterErrors, data);
  };
};
