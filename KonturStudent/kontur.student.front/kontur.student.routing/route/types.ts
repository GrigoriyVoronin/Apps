import { State } from 'router5';
import { Params } from 'router5/dist/types/base';
import { IRoute } from './IRoute';

export interface IRouterState extends State {
  redirectTo?: INavigationObject;
}

export interface IRouteBaseActions {
  navigate: <N extends string, O extends INavigationOptions = INavigationOptions>(
    route: N,
    routeParams?: Params,
    options?: O
  ) => void;
}

export interface INavigationOptions {
  replace?: boolean;
  reload?: boolean;
  skipTransition?: boolean;
  force?: boolean;
  error?: IDoneCallbackError;
  autoFillMode?: AutoFillEnum;
}

export interface INavigationObject {
  routeName: string;
  routeParams: Params;
  options?: INavigationOptions;
}

export interface IDoneCallbackError {}

export interface AutoFillEnum {}

export interface IAnyRoute extends IRoute<any, any, any> {}

export interface IRouteActions {}
