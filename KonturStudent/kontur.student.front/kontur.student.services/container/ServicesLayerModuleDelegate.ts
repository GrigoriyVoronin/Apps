import { IServiceFactory, IServicesLayerSettings } from './types';
import { TAddContainerModuleDelegate } from 'kontur.student.di';
import { serviceFactory } from './ServiceFactory';

export function getServicesLayerModuleDelegate(settings: IServicesLayerSettings): TAddContainerModuleDelegate {
  return function (bind, unbind, isBound, rebind) {
    bind(IServiceFactory).toFactory(serviceFactory);
    settings.singletoScopeBindings.forEach((binding) => {
      bind(binding.bind).to(binding.to).inSingletonScope();

      if (binding.bindSettings && binding.toSettings) {
        bind(binding.bindSettings).toConstantValue(binding.toSettings);
      }
    });
  };
}
