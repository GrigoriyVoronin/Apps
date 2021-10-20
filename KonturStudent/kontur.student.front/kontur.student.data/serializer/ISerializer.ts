import { inject, injectable } from 'kontur.student.di';
import { Instance, SnapshotIn, SnapshotOut } from 'mobx-state-tree';
import { TModel } from '../models/types';

@injectable()
export abstract class ISerializer<MT extends TModel, M = Instance<MT>, S = SnapshotOut<MT>, C = SnapshotIn<MT>> {
  protected readonly modelType: MT;

  constructor(@inject(TModel) ModelType: MT) {
    this.modelType = ModelType;
  }

  abstract serializeMany(model: M[]): any;
  abstract serializeSingle(model: M): any;
  abstract serializeId(snapshot: S): void;
  abstract inlineId(payload: S, id: string): void;
  abstract deserializeMany(payload: any[]): C[];
  abstract deserializeSingle(itemPayload: any): C;
  abstract deserializeId(itemPayload: S): void;
  abstract extractId(itemPayload: S): string | undefined;
}
