import { interfaces, ContainerHelpers } from 'kontur.student.di';
import { DI_KEY_DATA_TAG } from './ContainerTagsBuilder';
import { TModel } from '../models/types';

export function matchesDataTagWith(modelType: TModel, scope?: string) {
  return (request: interfaces.Request) => {
    const tag = ContainerHelpers.findRequestTag(request, DI_KEY_DATA_TAG);
    return !!tag && tag.modelType === modelType && (scope ? tag.scope === scope : true);
  };
}

export function hasNoOwnAdapter(request: interfaces.Request) {
  const tag = ContainerHelpers.findRequestTag(request, DI_KEY_DATA_TAG);
  return !tag || !tag.hasAdapter;
}

export function hasNoOwnSerializer(request: interfaces.Request) {
  const tag = ContainerHelpers.findRequestTag(request, DI_KEY_DATA_TAG);
  return !tag || !tag.hasSerializer;
}
