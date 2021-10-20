import React from 'react';

import { injectable, injectProperty } from 'kontur.student.di';
import { IPageInstance } from 'kontur.student.ui';

import { IRootPageProps, RootPage } from './RootPage';
import { IRouteParent } from 'kontur.student.routing/route/IRoute';
import { IRouterService } from '../../IRouterService';

@injectable()
export class RootRoute implements IRouteParent {
  public get title() {
    return '';
  }

  public page: React.CElement<IRootPageProps, RootPage>;
  private readonly pageReference: React.RefObject<RootPage>;
  @injectProperty(IRouterService) private routerService!: IRouterService;

  constructor() {
    this.pageReference = React.createRef();
    this.page = React.createElement(RootPage, { ref: this.pageReference });
  }

  public updateRoutesTree(children: IPageInstance) {
    if (this.pageReference.current) {
      this.pageReference.current.setState({ children });
    }
  }
}
