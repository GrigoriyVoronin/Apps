import type { interfaces } from 'kontur.student.di';

import { IRouteClassGetter } from './types';
import { IRoute } from '../route/IRoute';
import { routeFactory } from './RouteFactory';

export async function IRouteProvider(named: string, getter: IRouteClassGetter): Promise<IRoute> {
  throw new Error('IRouteProvider is not implemented');
}

export const routeProvider: interfaces.ProviderCreator<IRoute> = function routeProvider(context) {
  return async function (routeName: string, getter: IRouteClassGetter) {
    const concreteRoute = await getter();
    const factory = routeFactory(context);
    return factory(routeName, concreteRoute) as IRoute;
  };
};
