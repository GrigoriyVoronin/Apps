import { types, Instance, SnapshotOut } from 'mobx-state-tree';

type ModelMetaType = typeof ModelMeta;
export interface TModelMeta extends ModelMetaType {}
export interface IModelMeta extends Instance<TModelMeta> {}
export interface IModelMetaSnapshot extends SnapshotOut<TModelMeta> {}

export const ModelMeta = types
  .model({
    id: types.string,
    isNew: types.optional(types.boolean, false),
    isLoading: types.optional(types.boolean, false),
    isReloading: types.optional(types.boolean, false),
    isUpdating: types.optional(types.boolean, false),
    isSaving: types.optional(types.boolean, false),
    isDeleting: types.optional(types.boolean, false),
    isDeleted: types.optional(types.boolean, false),
  })
  .actions((self) => ({
    setId(id: string) {
      self.id = id;
    },
    setIsNew(isNew: boolean) {
      self.isNew = isNew;
    },
    setIsLoading(isLoading: boolean) {
      self.isLoading = isLoading;
    },
    setIsReloading(isReloading: boolean) {
      self.isReloading = isReloading;
    },
    setIsUpdating(isUpdating: boolean) {
      self.isUpdating = isUpdating;
    },
    setIsSaving(isSaving: boolean) {
      self.isSaving = isSaving;
    },
    setIsDeleting(isDeleting: boolean) {
      self.isDeleting = isDeleting;
    },
    setIsDeleted(isDeleted: boolean) {
      self.isDeleted = isDeleted;
    },
    reset() {
      (self.isDeleted = false),
        (self.isDeleting = false),
        (self.isLoading = false),
        (self.isNew = false),
        (self.isReloading = false),
        (self.isSaving = false),
        (self.isUpdating = false);
      // for(let key in self) {
      //     self[key] = false,
      // }
    },
  }))
  .views((self) => ({
    get isLoaded() {
      return !self.isNew && !self.isLoading && !self.isReloading;
    },
    get isInProgress() {
      return self.isLoading || self.isReloading || self.isSaving;
    },
  }));
