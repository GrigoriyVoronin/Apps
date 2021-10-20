import React from 'react';
import { Params } from 'router5/dist/types/base';

import { injectable } from 'kontur.student.di';
import type { IPageProps, ILoadingPageProps, IErrorPageProps, IPageInstance } from 'kontur.student.ui';

import { IRouterService } from '../IRouterService';
import { IRouterTransition } from '../transition/ITransition';
import {
  IRouterState,
  IRouteBaseActions,
  INavigationOptions,
  IAnyRoute,
  IRouteActions,
  IDoneCallbackError,
} from './types';

export interface IRouteParams {}

export abstract class IRouteParent {}

export const IRouteSymbol: unique symbol = Symbol.for('IRouteSymbol');

@injectable()
export abstract class IRoute<
  P extends IRouteParams = Params,
  M = any,
  A extends IRouteActions = IRouteActions,
  PARENT extends IAnyRoute = IAnyRoute
> extends IRouteParent {
  public abstract readonly name: string;
  public abstract readonly parent: PARENT; // ссылка на родительский роут
  public abstract readonly pageClass: React.ComponentType<IPageProps<P, M, A>>; // класс React-компонента страницы, которую надо отобразить.
  public abstract readonly loadingClass: React.ComponentType<ILoadingPageProps<P, A>>; // класс React-компонента страницы загрузки
  public abstract readonly errorClass: React.ComponentType<IErrorPageProps<P, A>>; // класс React-компонента страницы ошибки, которая покажется при ошибке в процессе перехода на роут

  protected abstract readonly router: IRouterService;

  protected abstract page: Nullable<React.ReactElement<IPageProps<P, M, A>>>; // инстанс компонента страницы
  protected abstract error: Nullable<React.ReactElement<IErrorPageProps<P, A>>>; // инстанс компонента страницы с ошибкой
  protected abstract loading: Nullable<React.ReactElement<ILoadingPageProps<P, A>>>; // инстанс компонента страницы загрузки

  public abstract init(): void;

  // Хуки жизненного цикла start
  public abstract canActivate(toState: IRouterState, fromState: IRouterState): MaybePromise<boolean>;

  public abstract activate(params: P, transition: IRouterTransition): MaybePromise<void>;

  public abstract beforeModel(params: P, transition: IRouterTransition): MaybePromise<void>;

  public abstract model(params: P, transition: IRouterTransition): MaybePromise<M>;

  public abstract afterModel(model: M, params: P, transition: IRouterTransition): MaybePromise<void>;

  public abstract canDeactivate(toState: IRouterState, fromState: IRouterState): MaybePromise<boolean>;

  public abstract deactivate(transition: IRouterTransition): MaybePromise<void>;

  public abstract afterDeactivated(transition: IRouterTransition): MaybePromise<void>;
  // Хуки жизненного цикла end

  protected abstract extendActions(): A; // функция, возращающая объект со специфичными для каждого роута экшены, которые расширят базовые экшены

  public get actions(): A & IRouteBaseActions {
    if (!this._actions) {
      const routeActions = this.extendActions();
      Object.keys(routeActions!).forEach((actionName) => {
        // ! для null в extendActions - потом убрать
        // @ts-ignore
        routeActions[actionName] = routeActions[actionName].bind(this);
      });
      this._actions = Object.assign({}, this._baseActions, routeActions);
    }

    return this._actions!;
  }

  public abstract updateRoutesTree(children: IPageInstance<any, any>): void;
  public abstract unmountPage(): void;
  public abstract renderLoading(transition: IRouterTransition, params: P): void;
  public abstract renderPage(props: IPageProps<P, M, A>): void;
  public abstract renderError(transition: Nullable<IRouterTransition>, error: IDoneCallbackError, params: P): void;

  private _actions = null as Nullable<A & IRouteBaseActions>;
  private _baseActions = {
    navigate: <N extends string>(route: N, routeParams?: Params, options?: INavigationOptions) => {
      this.router!.navigate(route, routeParams, options); // ! для null - потом убрать
    },
  } as IRouteBaseActions | null;

  public [IRouteSymbol]: true;
}
