import { AuthorizedRoute } from 'kontur.student.routing';

import { MentorsPage } from './MentorsPage';

export interface IMentorsRouteParams {}

export interface IMentorsRouteModel {
  test: string;
}

export class MentorsRoute extends AuthorizedRoute<IMentorsRouteParams, IMentorsRouteModel> {
  readonly pageClass = MentorsPage;

  public async model(): Promise<IMentorsRouteModel> {
    let testModel = {
      test: 'mentors page',
    };

    return await new Promise((resolve) => setTimeout(() => resolve(testModel), 1000));
  }
}
