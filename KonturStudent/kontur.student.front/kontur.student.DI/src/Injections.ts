import { interfaces, LazyServiceIdentifer } from 'inversify';
import getDecorators from 'inversify-inject-decorators';
import { ServiceIdentifierOrFunc } from 'inversify/dts/annotation/inject';
import { ContainerConfiguration } from './ContainerConfiguration';

const container = ContainerConfiguration.container;

export const DECORATORS = getDecorators(container, true);

export const injectProperty = function (serviceIdentifier: interfaces.ServiceIdentifier<any>) {
  const original = DECORATORS.lazyInject(serviceIdentifier);
  return function (this: any, proto: any, key: string): any {
    original.call(this, proto, key);
    return Object.getOwnPropertyDescriptor(proto, key);
  };
};

export const injectArguments = <DecoratedFn extends (...args: any) => any>(
  injectionTokens: ServiceIdentifierOrFunc[],
  receiverFunc: (...args: any) => DecoratedFn
): DecoratedFn => {
  return function (this: any, ...args: any): any {
    const injections = injectionTokens.map((dependency) => {
      if (dependency instanceof LazyServiceIdentifer) {
        return container.get(dependency.unwrap());
      }
      return container.get(dependency);
    });

    return receiverFunc(...injections).call(this, ...args);
  } as DecoratedFn;
};
