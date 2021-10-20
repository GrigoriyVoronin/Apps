import React from 'react';

import { Page } from 'kontur.student.ui';
import { IRouteParams } from 'kontur.student.routing';
import { IRouteActions } from 'kontur.student.routing';
import { IPageState } from 'kontur.student.ui';
import { IMentorsRouteModel } from './MentorsRoute';

export class MentorsPage<
  P extends IRouteParams = IRouteParams,
  M extends IMentorsRouteModel = IMentorsRouteModel,
  A extends IRouteActions = IRouteActions,
  S extends IPageState = IPageState
> extends Page<IRouteParams, IMentorsRouteModel, IPageState> {
  public render() {
    return <span>Hello from Mentor Page</span>;
  }
}
