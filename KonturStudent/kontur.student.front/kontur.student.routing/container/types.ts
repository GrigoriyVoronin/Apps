import { IServiceBinding } from 'kontur.student.services';
import { IAnyRoute } from '../route/types';
import { IRouteProvider } from './RouteProvider';

export interface IRoutingLayerSettings {
  services: IServiceBinding<any>[];
}
export type IRouteClassGetter = () => MaybePromise<IRouteClass>;
export interface IRouteClass {
  new (...args: any[]): IAnyRoute;
}
export abstract class IRouteName {}
export type TRouteProvider = typeof IRouteProvider;
