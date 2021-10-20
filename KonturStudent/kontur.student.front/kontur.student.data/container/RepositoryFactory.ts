import { IAnyRepository, IRepository } from '../repository/IRepository';
import { ContainerTagsBuilder, DI_KEY_DATA_TAG } from './ContainerTagsBuilder';
import { TModel } from '../models/types';
import { interfaces } from 'kontur.student.di';
import { IRepositoryFactory } from '../repository/types';
import { Repository } from '../repository/Repository';

export const repositoryFactory: interfaces.FactoryCreator<IAnyRepository> = function repositoryFactory(context) {
  const container = context.container;

  return function <MT extends TModel>(modelType: MT) {
    const tag = ContainerTagsBuilder.buildDataTag(modelType);

    if (!container.isBoundTagged(IRepository, DI_KEY_DATA_TAG, tag)) {
      container.bind(IRepository).to(Repository).inSingletonScope().whenTargetTagged(DI_KEY_DATA_TAG, tag);
    }

    return container.getTagged(IRepository, DI_KEY_DATA_TAG, tag);
  };
};
export type TRepositoryFactory = typeof IRepositoryFactory;
export function TRepositoryFactory() {}
