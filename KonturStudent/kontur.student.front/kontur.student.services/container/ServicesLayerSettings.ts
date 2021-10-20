import { IServicesLayerSettings } from './types';
import { LoggerService } from '../logger/LoggerService';
import { AuthorizationService } from '../authorization/AuthorizationService';
import { ILoggerService } from '../logger/ILoggerService';
import { IAuthorizationService } from '../authorization/IAuthorizationService';

export const ServicesLayerSettings: IServicesLayerSettings = {
  singletoScopeBindings: [
    {
      bind: ILoggerService,
      to: LoggerService,
    },
    {
      bind: IAuthorizationService,
      to: AuthorizationService,
    },
  ],
};
