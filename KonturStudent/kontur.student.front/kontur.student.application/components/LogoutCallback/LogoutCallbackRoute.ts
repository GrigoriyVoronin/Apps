import { IRouterService, IRouterTransition, Route, defaultRoute, IRouterState } from 'kontur.student.routing';
import { injectProperty } from 'kontur.student.di';
import { IAuthorizationService } from 'kontur.student.services';

export interface ILogoutCallbackParams {}
export interface ILogoutCallbackModel {}

export class LogoutCallbackRoute extends Route<ILogoutCallbackParams, ILogoutCallbackModel> {
  @injectProperty(IAuthorizationService) private readonly authorizationService!: IAuthorizationService;
  @injectProperty(IRouterService) private readonly routerService!: IRouterService;

  canDeactivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }

  canActivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }

  async activate(params: ILogoutCallbackParams, transition: IRouterTransition): Promise<void> {
    await this.authorizationService.finishLogout();
    this.routerService.navigate(defaultRoute, { replace: true, reload: true });
  }
}
