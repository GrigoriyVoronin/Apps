import { Params } from 'router5/dist/types/base';

import { IAuthorizationService } from 'kontur.student.services';
import { injectProperty } from 'kontur.student.di';

import { Route } from './Route';
import { IRouterService } from '../IRouterService';
import { IRouterState } from './types';
import { IRouteParams } from './IRoute';

export class AuthorizedRoute<P extends IRouteParams = Params, M = any> extends Route<P, M> {
  @injectProperty(IAuthorizationService) private readonly authorizationService!: IAuthorizationService;
  @injectProperty(IRouterService) private readonly routerService!: IRouterService;

  canDeactivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }

  async canActivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> {
    const hasOpenIdUser = this.authorizationService.hasOpenIdUser();
    if (!hasOpenIdUser) {
      await this.authorizationService.authorize();
    }
    return true;
  }
}
