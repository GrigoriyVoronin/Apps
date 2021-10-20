import { IDataLayerSettings } from './types';
import { TAddContainerModuleDelegate } from 'kontur.student.di';
import { IDataTransport } from '../transport/IDataTransport';
import { IResponseProcessor } from '../processors/IResponseProcessor';
import { TModel } from '../models/types';
import { IAdapter } from '../adapter/IAdapter';
import { hasNoOwnAdapter, hasNoOwnSerializer } from './ContainerConstraints';
import { dataErrorFactory, IDataErrorFactory } from '../errors/dataErrorFactory';
import { IRepositoryFactory } from '../repository/types';
import { repositoryFactory } from './RepositoryFactory';
import { Serializer } from '../serializer/Serializer';
import { ISerializer } from '../serializer/ISerializer';
import { DataError } from '../errors/DataError';
import { DataErrorType, TDataError } from '../errors/types';

export const getDataLayerModuleDelegate = (settings: IDataLayerSettings): TAddContainerModuleDelegate => {
  return function (bind) {
    settings.singletoScopeBindings.forEach((i) => bind(i.bind).to(i.to).inSingletonScope());
    bind(IDataTransport).toConstantValue(settings.transport).whenTargetIsDefault();
    bind(IResponseProcessor).to(settings.responseProcessor).inSingletonScope().whenTargetIsDefault();
    //bind(TModel).toConstantValue(settings.model).whenTargetIsDefault();
    bind(IAdapter).to(settings.adapter).when(hasNoOwnAdapter);
    bind(IDataErrorFactory).toFactory(dataErrorFactory);
    bind(IRepositoryFactory).toFactory(repositoryFactory);
    bind(ISerializer).to(Serializer).inSingletonScope().when(hasNoOwnSerializer);
    bind(TDataError).toConstructor(DataError).whenTargetNamed(DataErrorType.BadRequest);
  };
};
