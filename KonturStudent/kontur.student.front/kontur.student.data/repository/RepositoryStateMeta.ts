import { types } from 'mobx-state-tree';

export const RepositoryStateMeta = types
  .model('RepositoryStateMeta ', {
    isLoading: types.optional(types.boolean, false),
    isReloading: types.optional(types.boolean, false),
    lastOffset: types.union(types.string, types.undefined),
  })
  .actions((self) => ({
    setIsLoading(value: boolean) {
      self.isLoading = value;
    },
    setIsReloading(value: boolean) {
      self.isReloading = value;
    },
    setLastOffset(value?: string) {
      self.lastOffset = value;
    },
  }));
