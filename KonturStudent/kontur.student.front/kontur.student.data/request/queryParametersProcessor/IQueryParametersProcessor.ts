import { injectable } from 'kontur.student.di';
import { IUrlParamsShape, IObjectQueryParams } from '../types';

@injectable()
export abstract class IQueryParametersProcessor {
  abstract decodeParams(urlParams: IUrlParamsShape): IObjectQueryParams;
  abstract encodeParams(paramsObject: IObjectQueryParams): IUrlParamsShape;
  abstract stringify(paramsObject: IObjectQueryParams): string;
  abstract parse(url: string): IObjectQueryParams;
}
