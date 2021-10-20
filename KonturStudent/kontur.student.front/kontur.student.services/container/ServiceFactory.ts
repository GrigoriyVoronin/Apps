import type { interfaces } from 'inversify';

export const serviceFactory: interfaces.FactoryCreator<interfaces.ServiceIdentifier<any>> = function serviceFactory(
  context
) {
  const container = context.container;

  return function <T, SI extends interfaces.ServiceIdentifier<T>>(serviceIdentifier: SI): T {
    return container.get(serviceIdentifier);
  };
};
