import { getSnapshot, Instance, isStateTreeNode, SnapshotIn, SnapshotOut } from 'mobx-state-tree';
import { IModel, IModelCreate, IModelSnapshot, TModel } from '../models/Model';
import { ISerializer } from './ISerializer';
import { v4 as uuidv4 } from 'uuid';
export class Serializer<
  MT extends TModel = TModel,
  M extends IModel = Instance<MT>,
  S extends IModelSnapshot = SnapshotOut<MT>,
  C extends IModelCreate = SnapshotIn<MT>
> extends ISerializer<MT, M, S, C> {
  public serializeMany(models: M[]): S[] {
    const result: S[] = new Array(models.length);
    for (let i = 0; i < models.length; i++) {
      result[i] = this.serializeSingle(models[i]);
    }
    return result;
  }

  public serializeSingle(model: M): S {
    const snapshot = Object.assign({}, isStateTreeNode(model) ? getSnapshot(model) : model) as S;
    this.serializeId(snapshot);

    return snapshot;
  }

  public serializeId(snapshot: S): string {
    const id = snapshot.id;
    this.inlineId(snapshot, id);
    return id;
  }

  public inlineId(itemPayload: S, id: any): void {
    itemPayload.id = id;
  }

  public deserializeMany(payload: any[]): C[] {
    const result: C[] = new Array(payload.length);
    for (let i = 0; i < payload.length; i++) {
      result[i] = this.deserializeSingle(payload[i]);
    }
    return result;
  }

  public deserializeSingle(itemPayload: any): C {
    if (Object.isFrozen(itemPayload)) {
      itemPayload = Object.assign({}, itemPayload);
    }
    this.deserializeId(itemPayload);
    return itemPayload;
  }

  public deserializeId(snapshot: S) {
    const id = typeof snapshot.id === 'string' ? snapshot.id : this.extractId(snapshot);
    if (typeof id === 'string') {
      snapshot.id = id;
    }
  }

  public extractId(snapshot: S): string | undefined {
    const id = snapshot.id;

    return id;
    // ? id : uuidv4();
  }
}
