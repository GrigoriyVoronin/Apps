import { interfaces } from 'inversify';
import { IDataTag } from 'kontur.student.data';

export const ContainerHelpers = {
  findRequestTag(request: interfaces.Request, key: string): IDataTag | undefined {
    let currentRequest: Nullable<interfaces.Request> = request;
    while (currentRequest) {
      const tags = currentRequest.target.getCustomTags();
      const dataTag = tags && tags.find((t) => t.key === key);
      if (dataTag) {
        return dataTag.value;
      }
      currentRequest = currentRequest.parentRequest;
    }

    return undefined;
  },
};
