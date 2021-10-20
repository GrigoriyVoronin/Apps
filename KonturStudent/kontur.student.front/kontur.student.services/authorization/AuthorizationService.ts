import { SignoutResponse, UserManager } from 'oidc-client';

import { inject, LazyServiceIdentifer } from 'kontur.student.di';
import { IRouterService, TRouterService } from 'kontur.student.routing';

import { IAuthorizationService } from './IAuthorizationService';
import { IService } from '../base/IService';
import { IOIDCState, IOpenIdUser } from './types';

export class AuthorizationService extends IService implements IAuthorizationService {
  private readonly userManager: UserManager | undefined;
  private isSubscribedToUserManagerEvents = false;
  private openIdUser: IOpenIdUser | undefined = undefined;

  constructor(@inject(new LazyServiceIdentifer(() => IRouterService)) private readonly routerService: TRouterService) {
    super();
    const location = window.location;
    const port = location.port ? `:${location.port}` : '';
    const baseURL = `${location.protocol}//${location.hostname}${port}`;
    const loginCallbackURL = `${baseURL}/login-callback`;
    const logoutCallbackURL = `${baseURL}/logout-callback`;

    this.userManager = new UserManager({
      clockSkew: 300,
      authority: 'https://identity.testkontur.ru', // TODO: take authority from settings
      scope: 'openid profile email auth.sid',
      loadUserInfo: true,
      monitorSession: true, // NOTE: for logout sync to work across tabs
      filterProtocolClaims: true,
      automaticSilentRenew: true,
      client_id: 'KonturStudent',
      response_type: 'token id_token',
      redirect_uri: loginCallbackURL,
      post_logout_redirect_uri: logoutCallbackURL,
    });
  }

  async start() {
    return null;
  }

  async stop() {
    return null;
  }

  public async authorize(): Promise<void> {
    await this.tryLoadOpenIdUser();
    if (!this.hasOpenIdUser()) {
      await this.requestLogin({}, true);
    }
  }

  public async tryLoadOpenIdUser(): Promise<void> {
    const userPayload = await this.userManager?.getUser();
    if (userPayload) {
      this.openIdUser = userPayload;
      this.subscribeToUserManagerEvents();
    }
  }

  public hasOpenIdUser(): boolean {
    const user = this.openIdUser;
    return !!user && !this.expired;
  }

  private get expiresIn() {
    const user = this.openIdUser;
    if (!user) {
      return undefined;
    }
    if (user.expires_at) {
      const now = parseInt(`${Date.now() / 1000}`, 10);
      return user.expires_at - now;
    }
    return undefined;
  }

  private get expired() {
    const expiresIn = this.expiresIn;
    if (expiresIn !== undefined) {
      return expiresIn <= 0;
    }
    return undefined;
  }

  public getOpenIdUser(): IOpenIdUser {
    if (!this.openIdUser) {
      throw new Error('There is no OpenId user in Authorization service');
    }
    return this.openIdUser;
  }

  public isOpenIdUserAuthorized(): true | never {
    const user = this.openIdUser;
    if (!user || this.expired) {
      throw new Error(!user ? 'Пользователь не авторизован' : 'Сессия истекла');
    }

    return true;
  }

  public async finishLogin(): Promise<void> {
    const userPayload = await this.userManager?.signinRedirectCallback();
    this.openIdUser = userPayload;
    this.subscribeToUserManagerEvents();
    this.userManager?.clearStaleState();
  }

  public getAccessToken() {
    if (this.openIdUser && this.isOpenIdUserAuthorized()) {
      return this.openIdUser.access_token;
    }
    return '';
  }

  public async requestLogin(state?: IOIDCState, force = false): Promise<void> {
    if (force) {
      this.openIdUser = undefined;
    }
    if (!this.hasOpenIdUser()) {
      await this.userManager?.signinRedirect(state);
    }
  }

  public requestLogout = async (state: IOIDCState = {}): Promise<void> => {
    await this.userManager?.signoutRedirect(state);
  };

  public async finishLogout(state?: IOIDCState): Promise<SignoutResponse | undefined> {
    const signOutResponse = await this.userManager?.signoutRedirectCallback();
    if (signOutResponse) {
      await this.clearUserSession();
      return signOutResponse;
    }
  }

  private async clearUserSession() {
    this.unsubscribeFromUserManagerEvents();
    this.openIdUser = undefined;
    await this.userManager?.removeUser();
  }

  private subscribeToUserManagerEvents() {
    if (!this.isSubscribedToUserManagerEvents && this.userManager) {
      const events = this.userManager.events;
      events.addUserLoaded(this.updateOpenIdUser);
      events.addUserUnloaded(this.handleOpenIdUserExpired);
      events.addUserSignedOut(this.handleOpenIdUserSignedOut);
      events.addAccessTokenExpired(this.handleOpenIdUserExpired);
      events.addSilentRenewError(this.handleOpenIdUserSilentError);
      this.isSubscribedToUserManagerEvents = true;
    }
  }

  private unsubscribeFromUserManagerEvents() {
    if (this.isSubscribedToUserManagerEvents && this.userManager) {
      const events = this.userManager.events;
      events.removeUserLoaded(this.updateOpenIdUser);
      events.removeUserUnloaded(this.updateOpenIdUser);
      events.removeUserSignedOut(this.handleOpenIdUserSignedOut);
      events.removeAccessTokenExpired(this.handleOpenIdUserExpired);
      events.removeSilentRenewError(this.handleOpenIdUserSilentError);
      this.isSubscribedToUserManagerEvents = false;
    }
  }

  private updateOpenIdUser = async (userPayload?: IOpenIdUser) => {
    this.openIdUser = userPayload;
  };

  private handleOpenIdUserSignedOut = () => {
    this.routerService.navigate('logout-callback');
  };

  private handleOpenIdUserExpired = () => {
    this.requestLogin(this.buildRequestLoginDefaultState());
  };

  private handleOpenIdUserSilentError = () => {
    this.requestLogin(this.buildRequestLoginDefaultState());
  };

  private buildRequestLoginDefaultState = (): Partial<IOIDCState> => {
    return {};
  };
}
