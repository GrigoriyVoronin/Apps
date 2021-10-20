import { User } from 'oidc-client';

export interface IOpenIdUser extends User {
  // idToken: string;
  // sessionState: string;
  // accessToken: string;
  // refreshToken?: string;
  // tokenType: string;
  // scope?: string;
  // expiresAt?: number;
  // profile: {
  //     sid?: string;
  //     sub?: string;
  //     authTime?: number;
  //     idp?: string;
  //     givenName?: string;
  //     familyName?: string;
  //     middleName?: string;
  //     name?: string;
  //     updatedAt?: number;
  //     amr?: string[];
  // };
}
export interface IOIDCBackObject {
  pathname: string;
  search?: string;
  hash?: string;
}

export interface IOIDCState {
  back?: IOIDCBackObject;
}
