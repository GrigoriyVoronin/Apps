import { Params } from 'router5/dist/types/base';
import { INavigationOptions, IRouterState } from '../route/types';
import { IRouterTransitionAbortReason } from './types';

export interface IRouterTransition {
  readonly fromState: IRouterState;
  readonly toState: IRouterState;
  readonly continueExecution: boolean;

  redirectTo<N extends string>(route: N, routeParams?: Params, options?: INavigationOptions): void;

  redirectToURL(url: string): void;

  cancel(): void;

  abort(reason: IRouterTransitionAbortReason): void;
}
