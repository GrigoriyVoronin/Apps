import { IResponseProcessor } from './IResponseProcessor';

export abstract class TResponseProcessor {}

export interface TResponseProcessor {
  new (...args: any[]): IResponseProcessor;
}
