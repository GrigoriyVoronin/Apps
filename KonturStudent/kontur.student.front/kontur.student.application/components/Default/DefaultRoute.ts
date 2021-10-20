import { IRouterState, IRouterTransition, Route } from 'kontur.student.routing';
import { DefaultPage } from './DefaultPage';
import { injectProperty } from 'kontur.student.di';
import { IAuthorizationService } from 'kontur.student.services';
import { IHomeRouteParams } from '../Home/HomeRoute';

export interface IDefaultRouteParams {}
export interface IDefaultRouteModel {}

export class DefaultRoute extends Route<IDefaultRouteParams, IDefaultRouteModel> {
  readonly pageClass = DefaultPage;
  @injectProperty(IAuthorizationService) private readonly authorizationService!: IAuthorizationService;

  canDeactivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }

  canActivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }
}
