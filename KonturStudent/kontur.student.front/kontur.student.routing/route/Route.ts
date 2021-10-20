import React from 'react';
import { inject, LazyServiceIdentifer } from 'kontur.student.di';
import { Params } from 'router5/dist/types/base';

import {
  TPage,
  TLoadingPage,
  TErrorPage,
  IPageProps,
  ILoadingPageProps,
  IErrorPageProps,
  IPageError,
  IPageInstance,
} from 'kontur.student.ui';

import { IRoute, IRouteParams } from 'kontur.student.routing/route/IRoute';
import { IRouterState, IRouteActions, IAnyRoute } from 'kontur.student.routing/route/types';
import { IRouterTransition } from 'kontur.student.routing/transition/ITransition';
import { IRouterService } from 'kontur.student.routing/IRouterService';
import { IRouteName } from 'kontur.student.routing/container/types';
import { IRouteParentFactory } from 'kontur.student.routing/container/IRouteParentFactory';
import type { TRouteParentFactory } from 'kontur.student.routing/container/IRouteParentFactory';
import { TRepositoryFactory, IRepositoryFactory } from 'kontur.student.data';
import { IServiceFactory, TServiceFactory } from 'kontur.student.services';

export class Route<
  P extends IRouteParams = Params,
  M = any,
  A extends IRouteActions = IRouteActions,
  PARENT extends IAnyRoute = IAnyRoute
> extends IRoute {
  protected error: Nullable<React.ReactElement<IErrorPageProps<Params, IRouteActions>>>;
  protected loading: Nullable<React.ReactElement<ILoadingPageProps<Params, IRouteActions>>>;
  protected page: Nullable<React.ReactElement<IPageProps<Params, any, IRouteActions>>>;
  readonly parent: IAnyRoute;

  constructor(
    @inject(new LazyServiceIdentifer(() => TPage))
    readonly pageClass: React.ComponentType<IPageProps<Params, any, IRouteActions>>,
    @inject(new LazyServiceIdentifer(() => TLoadingPage))
    readonly loadingClass: React.ComponentType<ILoadingPageProps<Params, IRouteActions>>,
    @inject(new LazyServiceIdentifer(() => TErrorPage))
    readonly errorClass: React.ComponentType<IErrorPageProps<Params, IRouteActions>>,
    @inject(new LazyServiceIdentifer(() => IRouterService))
    protected readonly router: IRouterService,
    @inject(new LazyServiceIdentifer(() => IRouteName))
    readonly name: string,
    @inject(new LazyServiceIdentifer(() => IRouteParentFactory))
    protected routeParentFactory: TRouteParentFactory,
    @inject(new LazyServiceIdentifer(() => IRepositoryFactory))
    protected repositoryFor: TRepositoryFactory,
    @inject(new LazyServiceIdentifer(() => IServiceFactory))
    protected serviceFor: TServiceFactory
  ) {
    super();
    this.parent = routeParentFactory(name) as PARENT;
    this.error = null;
    this.loading = null;
    this.page = null;
    this.name = name;
  }

  activate(params: P, transition: IRouterTransition): Promise<void> | void {
    return undefined;
  }

  afterDeactivated(transition: IRouterTransition): Promise<void> | void {
    return undefined;
  }

  afterModel(model: any, params: P, transition: IRouterTransition): Promise<void> | void {
    return undefined;
  }

  beforeModel(params: P, transition: IRouterTransition): Promise<void> | void {
    return undefined;
  }

  canActivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return false;
  }

  canDeactivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return false;
  }

  deactivate(transition: IRouterTransition): Promise<void> | void {
    return undefined;
  }

  init(): void {}

  model(params: P, transition: IRouterTransition) {}

  renderError(transition: IRouterTransition | null, error: IPageError, params: P): void {
    const props = { transition, error, params, actions: this.actions };
    this.error = this.error ? React.cloneElement(this.error, props) : React.createElement(this.errorClass, props);

    this.parent.updateRoutesTree(this.error);
  }

  renderLoading(transition: IRouterTransition, params: Params): void {
    const props = { transition, params, actions: this.actions };
    this.loading = this.loading
      ? React.cloneElement(this.loading, props)
      : React.createElement(this.loadingClass, props);

    this.parent.updateRoutesTree(this.loading);
  }

  renderPage(props: IPageProps<P, M, A>): void {
    this.page = this.page ? React.cloneElement(this.page, props) : React.createElement(this.pageClass, props);

    this.parent.updateRoutesTree(this.page);
  }

  unmountPage(): void {
    this.parent.updateRoutesTree(null);
  }

  updateRoutesTree(children: IPageInstance<P, M, A>): void {
    if (!this.page) {
      throw new Error(`The child tries to update before this route (${this.name}) was initialized`);
    }
    this.page = React.cloneElement(this.page, {}, children);
    this.parent.updateRoutesTree(this.page);
  }

  protected extendActions(): A {
    return {} as A;
  }
}
