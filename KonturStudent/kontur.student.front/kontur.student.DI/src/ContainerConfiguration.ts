import 'reflect-metadata';
import { ContainerModule, interfaces } from 'inversify';
import { getServicesLayerModuleDelegate, IServicesLayerSettings } from 'kontur.student.services';
import { getDataLayerModuleDelegate, IDataLayerSettings } from 'kontur.student.data';
import { getRoutingLayerModuleDelegate, IRoutingLayerSettings } from 'kontur.student.routing';
import { getUILayerModuleDelegate, IUiLayerSettings } from 'kontur.student.ui';

import { TAddContainerModuleDelegate, TConfigureContainerDelegate } from '../types';
import { IAppLayersSettings } from 'kontur.student.application';
import { AppLayersSettings } from 'kontur.student.application';
import { CONTAINER_INSTANCE } from './ContainerInsance';

export enum ContainerModuleNames {
  Data = 'data',
  Services = 'services',
  Ui = 'ui',
  Routing = 'routing',
}

export class ContainerConfiguration {
  private static readonly applicationContainer: interfaces.Container = CONTAINER_INSTANCE;
  private static readonly containerModules: Map<ContainerModuleNames, interfaces.ContainerModule> = new Map();

  public static get container() {
    return this.applicationContainer;
  }

  public static init(settings: IAppLayersSettings = AppLayersSettings) {
    this.loadServicesLayer(settings.services);
    this.loadRouting(settings.routing);
    this.loadDataLayer(settings.data);
    this.loadUiLayer(settings.ui);
  }

  public static configure(configureDelegate: TConfigureContainerDelegate): void {
    configureDelegate(this.applicationContainer);
  }

  public static loadModule(name: ContainerModuleNames, add: TAddContainerModuleDelegate): void {
    if (!this.containerModules.has(name)) {
      const module = new ContainerModule(add);
      this.containerModules.set(name, module);
    }

    this.applicationContainer.load(this.containerModules.get(name)!);
  }

  public static loadDataLayer(settings: IDataLayerSettings) {
    this.loadModule(ContainerModuleNames.Data, getDataLayerModuleDelegate(settings));
  }

  public static loadServicesLayer(settings: IServicesLayerSettings) {
    this.loadModule(ContainerModuleNames.Services, getServicesLayerModuleDelegate(settings));
  }

  public static loadUiLayer(settings: IUiLayerSettings) {
    this.loadModule(ContainerModuleNames.Ui, getUILayerModuleDelegate(settings));
  }

  public static loadRouting(settings: IRoutingLayerSettings) {
    this.loadModule(ContainerModuleNames.Routing, getRoutingLayerModuleDelegate(settings));
  }
}
