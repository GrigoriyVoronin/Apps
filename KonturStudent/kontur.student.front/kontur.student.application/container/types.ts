import { IDataLayerSettings } from 'kontur.student.data';
import { IRoutingLayerSettings } from 'kontur.student.routing';
import { IUiLayerSettings } from 'kontur.student.ui';
import { IServicesLayerSettings } from 'kontur.student.services';

export interface IAppLayersSettings {
  data: IDataLayerSettings;
  routing: IRoutingLayerSettings;
  ui: IUiLayerSettings;
  services: IServicesLayerSettings;
}
