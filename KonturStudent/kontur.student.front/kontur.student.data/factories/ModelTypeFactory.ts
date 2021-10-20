import { CONTAINER_INSTANCE } from 'kontur.student.di';
import { IAnyModelType, ModelProperties } from 'mobx-state-tree';
import { IModelType, ModelSnapshotType, types } from 'mobx-state-tree';
import { ContainerTagsBuilder, matchesDataTagWith, Model } from '..';
import { IModelEndpoint, IModelSettings, TModel } from '../models/types';
import { ExtractCFromProps, ExtractOthers, ExtractProps } from 'mobx-state-tree/dist/types/complex-types/model';

const DEFAULT_MODEL_SETTINGS: IModelSettings = {
  shouldReloadRecord: true,
  shouldBackgroundReloadRecord: true,
  shouldReloadAll: true,
  shouldBackgroundReloadAll: true,
  shouldLoadLink: true,
};

export type IConcreteModelType<BASE extends IAnyModelType, P extends ModelProperties, O, FC, FS> = Omit<
  IConcreteModelTypeBase<BASE, P, O, FC, FS>,
  'create'
> & {
  create(
    snapshot: IConcreteModelTypeBase<BASE, P, O, FC, FS>['CreationType'],
    env?: Record<string, any>
  ): IConcreteModelTypeBase<BASE, P, O, FC, FS>['Type'];
};

type IConcreteModelTypeBase<BASE extends IAnyModelType, P extends ModelProperties, O, FC, FS> = IModelType<
  P & ExtractProps<BASE>,
  O & ExtractOthers<BASE> & FC & ExtractCFromProps<ExtractProps<BASE>>,
  FS & ModelSnapshotType<ExtractProps<BASE>>
>;

export class ModelTypeFactory {
  public static create<P extends ModelProperties, O, FC, FS>(
    source: IModelType<P, O, FC, FS>,
    endpoint: string,
    settings?: Partial<IModelSettings>
  ): IConcreteModelType<TModel, P, O, FC, FS> {
    const modelType = this.buildModelType(source);

    this.bindCommon(modelType, settings);

    CONTAINER_INSTANCE.bind(IModelEndpoint).toConstantValue(endpoint).when(matchesDataTagWith(modelType));

    return modelType as IConcreteModelType<TModel, P, O, FC, FS>;
  }

  private static buildModelType(modelType: IAnyModelType): IAnyModelType {
    const name = this.getModelName(modelType);

    return types.compose(name, Model, modelType);
  }

  private static bindCommon<P extends ModelProperties, O, FC, FS>(
    modelType: TModel,
    settings?: Partial<IModelSettings>
  ) {
    ContainerTagsBuilder.buildDataTag(modelType);

    CONTAINER_INSTANCE.bind(TModel).toConstantValue(modelType).when(matchesDataTagWith(modelType));

    CONTAINER_INSTANCE.bind(IModelSettings)
      .toConstantValue(Object.assign({}, DEFAULT_MODEL_SETTINGS, settings as IModelSettings))
      .when(matchesDataTagWith(modelType));
  }

  private static getModelName(sourceModelType: IAnyModelType) {
    return `${sourceModelType.name.replace(/(DTO|Contract|Model)$/, '')}Model`;
  }
}
