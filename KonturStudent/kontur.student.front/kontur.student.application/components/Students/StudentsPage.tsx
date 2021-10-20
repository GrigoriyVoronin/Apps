import React from 'react';

import { Page } from 'kontur.student.ui';
import { IRouteParams } from 'kontur.student.routing';
import { IRouteActions } from 'kontur.student.routing';
import { IPageState } from 'kontur.student.ui';
import { IStudentsRouteModel } from './StudentsRoute';

export class StudentsPage<
  P extends IRouteParams = IRouteParams,
  M extends IStudentsRouteModel = IStudentsRouteModel,
  A extends IRouteActions = IRouteActions,
  S extends IPageState = IPageState
> extends Page<IRouteParams, IStudentsRouteModel, IPageState> {
  public render() {
    return <span>Hello from Student Page</span>;
  }
}
