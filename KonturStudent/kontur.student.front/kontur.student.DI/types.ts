import { interfaces } from 'inversify';

interface IContainerRegistry {
  [key: string]: IContainerRegistry | { new (...args: any): any };
}

export type TConfigureContainerDelegate = (container: interfaces.Container) => void;
export type TAddContainerModuleDelegate = (
  bind: interfaces.Bind,
  unbind: interfaces.Unbind,
  isBound: interfaces.IsBound,
  rebind: interfaces.Rebind
) => void;

export interface IBabelPropertyDescriptor extends PropertyDescriptor {
  initializer(): any;
}
