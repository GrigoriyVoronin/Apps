import { interfaces } from 'kontur.student.di';
import { IRouteClass, IRouteName } from '..';
import { IRoute } from '../route/IRoute';

export type TRouteFactory = Function;

export function IRouteFactory(routeName: string, concreteRoute: IRouteClass): IRoute {
  throw new Error('IRouteFactory is not implemented');
}

export const routeFactory: interfaces.FactoryCreator<IRoute> = function routeFactory(context) {
  const container = context.container;

  return function (routeName: string, concreteRoute: IRouteClass) {
    if (!container.isBoundNamed(IRoute, routeName)) {
      container.bind(IRoute).to(concreteRoute).inSingletonScope().whenTargetNamed(routeName);
      container.bind(IRouteName).toConstantValue(routeName).whenParentNamed(routeName);
    }

    return container.getNamed(IRoute, routeName);
  };
};
