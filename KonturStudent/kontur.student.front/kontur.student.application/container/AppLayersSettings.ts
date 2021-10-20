import { IAppLayersSettings } from './types';
import { DataLayerSettings } from 'kontur.student.data';
import { RoutingLayerSettings } from 'kontur.student.routing';
import { UiLayerSettings } from 'kontur.student.ui';
import { ServicesLayerSettings } from 'kontur.student.services';

export const AppLayersSettings: IAppLayersSettings = {
  data: DataLayerSettings,
  routing: RoutingLayerSettings,
  ui: UiLayerSettings,
  services: ServicesLayerSettings,
};
