import { SignoutResponse } from 'oidc-client';
import { IService } from '../base/IService';
import { IOpenIdUser, IOIDCState } from './types';

export abstract class IAuthorizationService extends IService {
  public abstract tryLoadOpenIdUser(): Promise<void>;
  public abstract hasOpenIdUser(): boolean;
  public abstract getOpenIdUser(): IOpenIdUser;
  public abstract isOpenIdUserAuthorized(): true | never;
  public abstract requestLogin(state?: IOIDCState, force?: boolean): Promise<any>;
  public abstract finishLogin(): Promise<void>;
  public abstract getAccessToken(): string;
  public abstract requestLogout(state?: IOIDCState): Promise<void>;
  public abstract finishLogout(state?: IOIDCState): Promise<SignoutResponse | undefined>;
  public abstract authorize(): Promise<void>;
}

export type TAuthorizationService = IAuthorizationService;
