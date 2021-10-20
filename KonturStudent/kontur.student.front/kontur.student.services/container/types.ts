import { interfaces } from 'kontur.student.di';

export type IServiceBinding<T, S = any> = {
  bind: interfaces.ServiceIdentifier<T>;
  to: interfaces.Newable<T>;
} & ({ bindSettings: S; toSettings: S } | { bindSettings?: never; toSettings?: never });

export interface IServicesLayerSettings {
  singletoScopeBindings: IServiceBinding<any>[];
}

export function IServiceFactory<T, R extends T>(serviceIdentifier: interfaces.ServiceIdentifier<T>): R {
  throw new Error('IServiceFactory is not implemented');
}

export type TServiceFactory = typeof IServiceFactory;
export function TServiceFactory() {}
