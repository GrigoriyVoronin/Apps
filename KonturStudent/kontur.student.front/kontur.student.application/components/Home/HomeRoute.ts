import { AuthorizedRoute } from 'kontur.student.routing';

import { HomePage } from './HomePage';
import { IRouterState } from 'kontur.student.routing/route/types';

export interface IHomeRouteParams {}

export interface IHomeRouteModel {
  test: string;
}

export class HomeRoute extends AuthorizedRoute<IHomeRouteParams, IHomeRouteModel> {
  readonly pageClass = HomePage;

  public async model(): Promise<IHomeRouteModel> {
    let testModel = {
      test: 'home page',
    };

    return await new Promise((resolve) => setTimeout(() => resolve(testModel), 1000));
  }
}
