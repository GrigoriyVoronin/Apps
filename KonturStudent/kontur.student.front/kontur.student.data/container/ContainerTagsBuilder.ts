type IAnyModelType = any;
type TModel = any;

export const DI_KEY_DATA_TAG = '__$DATA_TAG_KEY$__';
export const DI_KEY_DATA_DEFAULT_SCOPE = '__$DATA_DEFAULT_SCOPE$__';

export interface IDataTag {
  modelType: TModel;
  scope: string;
  hasAdapter: boolean;
  hasSerializer: boolean;
}

const DataTag = (function (this: IDataTag, modelType: TModel, scope: string) {
  this.modelType = modelType;
  this.scope = scope;
  this.hasAdapter = false;
  this.hasSerializer = false;
} as unknown) as { new (modelType: TModel, scope: string): IDataTag };

export class ContainerTagsBuilder {
  private static dataTagsCache = new Map<TModel, Map<string, IDataTag>>();

  public static buildDataTag<T extends IAnyModelType>(modelType: T, scope = DI_KEY_DATA_DEFAULT_SCOPE): IDataTag {
    const modelTypeCache = this.dataTagsCache.get(modelType);
    if (!modelTypeCache) {
      const dataTag = new DataTag(modelType, scope);
      this.dataTagsCache.set(modelType, new Map([[scope, dataTag]]));
      return dataTag;
    }

    const scopeCache = modelTypeCache.get(scope);
    if (!scopeCache) {
      const dataTag = new DataTag(modelType, scope);
      modelTypeCache.set(scope, dataTag);
      return dataTag;
    }

    return scopeCache;
  }
}
