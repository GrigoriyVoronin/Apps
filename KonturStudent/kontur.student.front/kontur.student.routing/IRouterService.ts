import { Params } from 'router5/dist/types/base';

import { IService } from 'kontur.student.services';

import { INavigationOptions } from './route/types';
import React from 'react';

export abstract class IRouterService extends IService {
  public abstract navigate<N extends string = string, O extends INavigationOptions = INavigationOptions>(
    route: N,
    routeParams?: Params,
    options?: O
  ): void;

  public abstract getRootPage(): React.ReactElement;
}

export type TRouterService = IRouterService;
