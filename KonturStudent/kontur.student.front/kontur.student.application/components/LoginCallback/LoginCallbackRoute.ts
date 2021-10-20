import { IRouterService, IRouterState, IRouterTransition, Route, RoutesNames } from 'kontur.student.routing';
import { injectProperty } from 'kontur.student.di';
import { IAuthorizationService } from 'kontur.student.services';

export interface ILoginCallbackRouteParams {}
export interface ILoginCallbackRouteModel {}

export class LoginCallbackRoute extends Route<ILoginCallbackRouteParams, ILoginCallbackRouteModel> {
  @injectProperty(IAuthorizationService) private readonly authorizationService!: IAuthorizationService;
  @injectProperty(IRouterService) private readonly routerService!: IRouterService;

  canDeactivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }

  canActivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }

  async activate(params: ILoginCallbackRouteParams, transition: IRouterTransition): Promise<void> {
    await this.authorizationService.finishLogin();
    this.routerService.navigate(RoutesNames.Default);
  }
}
