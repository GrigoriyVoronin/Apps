import { TAddContainerModuleDelegate } from 'kontur.student.di';
import { IRoutingLayerSettings } from './types';
import { IRouteFactory, routeFactory } from './RouteFactory';
import { IRouteParentFactory, routeParentFactory } from './IRouteParentFactory';
import { IRouteProvider, routeProvider } from './RouteProvider';
import { IRouteParent } from '../route/IRoute';
import { RootRoute } from '../route/Root/RootRoute';

export const getRoutingLayerModuleDelegate = (settings: IRoutingLayerSettings): TAddContainerModuleDelegate => {
  return function (bind) {
    settings.services.forEach((i) => {
      bind(i.bind).to(i.to).inSingletonScope();
      bind(IRouteFactory).toFactory(routeFactory);
      bind(IRouteParentFactory).toFactory(routeParentFactory);
      bind(IRouteProvider).toProvider(routeProvider);
      bind(IRouteParent).to(RootRoute).inSingletonScope().whenTargetIsDefault();
    });
  };
};
