import React from 'react';
import createRouter from 'router5';
import { Router } from 'router5';
import browserPlugin from 'router5-plugin-browser';
import { Params } from 'router5/dist/types/base';

import { IService } from 'kontur.student.services';
import { inject, injectProperty, LazyServiceIdentifer } from 'kontur.student.di';

import { IRouteNode, RoutesTree, defaultRoute } from './RoutesTree';
import navigateToPath from './middlewares';
import { IRouterService } from './IRouterService';
import type { TRouteProvider } from './container/types';
import { IRouteProvider } from './container/RouteProvider';
import { IRouteParent } from './route/IRoute';
import { RootRoute } from './route/Root/RootRoute';
import { IRouteFactory } from './container/RouteFactory';
import type { TRouteFactory } from './container/RouteFactory';
import { IDoneCallbackError, INavigationObject, IRouterState } from './route/types';

export interface IRouterDependencies {
  routeFactory: TRouteFactory;
  routeProvider: TRouteProvider;
  routesTree: IRouteNode[];
}

export class RouterService extends IService implements IRouterService {
  private router!: Router<IRouterDependencies>;
  @injectProperty(IRouteParent)
  private rootRoute!: RootRoute;
  private handleNavigateDone = (error?: IDoneCallbackError, state?: IRouterState) => {
    if (error) {
      return;
    }

    const redirectTo = state?.redirectTo;
    if (state && redirectTo) {
      this.scheduleRedirect(redirectTo);
    }
  };

  private scheduleRedirect(navigateInfo: INavigationObject) {
    Promise.resolve(navigateInfo).then((info) => {
      this.navigate(info.routeName, info.routeParams, info.options);
    });
  }

  constructor(
    @inject(new LazyServiceIdentifer(() => IRouteFactory))
    private readonly routeFactory: TRouteFactory,
    @inject(new LazyServiceIdentifer(() => IRouteProvider))
    private readonly routeProvider: TRouteProvider
  ) {
    super();
    const dependencies: IRouterDependencies = {
      routeFactory: routeFactory,
      routesTree: RoutesTree,
      routeProvider: this.routeProvider,
    };
    this.router = createRouter(
      RoutesTree,
      {
        queryParamsMode: 'loose',
        defaultRoute: defaultRoute,
      },
      dependencies
    );
  }

  public async start() {
    this.router.usePlugin(browserPlugin());
    this.router.useMiddleware(navigateToPath);
    this.router.start();
  }

  public async stop() {}

  navigate<N extends string, O>(route: N, routeParams: Params = {}, options?: O): void {
    this.router.navigate(route, routeParams, this.handleNavigateDone);
  }

  getRootPage = (): React.ReactElement => this.rootRoute.page;
}
