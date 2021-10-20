import { interfaces } from 'kontur.student.di';
import { IRoute, IRouteParent } from '../route/IRoute';
import { RootRoute } from 'kontur.student.routing/route/Root/RootRoute';

export type TRouteParentFactory = Function;

export function IRouteParentFactory(routeName: string): IRoute {
  throw new Error('IRouteFactory is not implemented');
}

export const routeParentFactory: interfaces.FactoryCreator<IRoute | RootRoute> = function routeParentFactory(context) {
  const container = context.container;

  return function (routeName: string) {
    const isNestedRoute = routeName.includes('.');

    if (isNestedRoute) {
      const parentName = routeName.substr(0, routeName.lastIndexOf('.'));
      if (container.isBoundNamed(IRoute, parentName)) {
        return container.getNamed(IRoute, parentName) as IRoute;
      }
      throw new Error(`Trying to activate the child (${routeName}), which parent has no initialized instance`);
    }

    return container.get(IRouteParent) as RootRoute;
  };
};
