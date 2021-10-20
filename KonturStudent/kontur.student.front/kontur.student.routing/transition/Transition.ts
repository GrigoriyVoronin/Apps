import { Params } from 'router5/dist/types/base';

import { IRouterTransition } from './ITransition';
import { INavigationOptions, IRouterState } from '../route/types';
import {
  IRouterCancelFn,
  IRouterDoneFn,
  IRouterTransitionAbortReason,
  IRouterTransitionParams,
  IRouterTransitionPath,
} from './types';

// заглушка?
type IMatchURLDelegate = any;

export class RouterTransition implements IRouterTransition {
  public readonly fromState: IRouterState;
  public readonly toState: IRouterState;
  public readonly transitionPaths: IRouterTransitionPath;

  private readonly _done: IRouterDoneFn;
  private readonly _cancel: IRouterCancelFn;
  private readonly _matchURL: IMatchURLDelegate;
  private _preventExecution: boolean;
  private _toActivateStep: string;
  private _targetStep: Nullable<string>;

  constructor(params: IRouterTransitionParams) {
    const transitionPaths = params.transitionPaths;
    this.transitionPaths = transitionPaths;
    this.fromState = params.fromState;
    this.toState = params.toState;

    this._done = params.done;
    this._cancel = params.cancel;
    this._matchURL = params.matchURL;
    this._preventExecution = false;
    this._toActivateStep = '';
    this._targetStep = transitionPaths.toActivate[transitionPaths.toActivate.length - 1];
  }

  public setStepToActivate(path: string) {
    this._toActivateStep = path;
  }

  get continueExecution() {
    const targetStep = this._targetStep;

    if (targetStep === null) {
      return false;
    }

    const toActivate = this.transitionPaths.toActivate;
    const toActivateStepIndex = toActivate.findIndex((x) => x === this._toActivateStep);
    const targetStepIndex = toActivate.findIndex((x) => x === targetStep);

    const hasStep = toActivateStepIndex <= targetStepIndex;
    const stepIsDeeper = !hasStep && targetStep.startsWith(`${this._toActivateStep}`);
    return hasStep || stepIsDeeper;
  }

  public redirectToURL(url: string) {
    const targetState = this._matchURL(url);
    if (targetState) {
      this.redirectTo(targetState.name, targetState.params);
    } else {
      throw new Error(`Could not match url=${url} to any route`);
    }
  }

  public redirectTo<N extends string, O extends INavigationOptions = INavigationOptions>(
    route: N,
    routeParams: Params,
    options?: O
  ) {
    const routeName = `${route}`;
    this.toState.redirectTo = { routeName, routeParams, options };
    const toActivate = this.transitionPaths.toActivate;
    const hasStep = toActivate.includes(routeName);
    const stepIsDeeper = !hasStep && routeName.startsWith(`${this._toActivateStep}`);
    this._targetStep = hasStep || stepIsDeeper ? routeName : null;
  }

  public abort(reason: IRouterTransitionAbortReason = { code: 'TRANSITION_ABORTED_BY_ROUTE' }) {
    this._targetStep = null;
    this._done(reason);
  }

  public cancel() {
    this._targetStep = null;
    this._cancel();
  }
}
