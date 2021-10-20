import { IRoutingLayerSettings } from './types';
import { IRouterService } from '../IRouterService';
import { RouterService } from '../RouterService';

export const RoutingLayerSettings: IRoutingLayerSettings = {
  services: [
    {
      bind: IRouterService,
      to: RouterService,
    },
  ],
};
