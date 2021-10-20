import { AuthorizedRoute } from 'kontur.student.routing';

import { StudentsPage } from './StudentsPage';

export interface IStudentsRouteParams {}

export interface IStudentsRouteModel {
  test: string;
}

export class StudentsRoute extends AuthorizedRoute<IStudentsRouteParams, IStudentsRouteModel> {
  readonly pageClass = StudentsPage;

  public async model(): Promise<IStudentsRouteModel> {
    let testModel = {
      test: 'home page',
    };

    return await new Promise((resolve) => setTimeout(() => resolve(testModel), 1000));
  }
}
