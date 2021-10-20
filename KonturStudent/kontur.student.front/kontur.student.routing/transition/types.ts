import { IRouterState } from '../route/types';
import { TransitionPath } from 'router5-transition-path/dist/transitionPath';
import { ActivationFn } from 'router5';
import { CancelFn, DoneFn } from 'router5/dist/types/base';

export interface IRouterTransitionAbortReason {
  code?: string;
  data?: any;
}

export interface IRouterTransitionParams {
  fromState: IRouterState;
  toState: IRouterState;
  transitionPaths: IRouterTransitionPath;
  done: IRouterDoneFn;
  cancel: IRouterCancelFn;
  matchURL: IMatchURLDelegate;
}

export interface IRouterTransitionPath extends TransitionPath {} // TransitionPath из router5
export type IRouterActivationFn = ActivationFn; // ActivationFnиз router5
export type IRouterDoneFn = DoneFn; // DoneFnиз router5
export type IRouterCancelFn = CancelFn; // CancelFnиз router5
export type IMatchURLDelegate = (url: string) => Nullable<IRouterState>;
