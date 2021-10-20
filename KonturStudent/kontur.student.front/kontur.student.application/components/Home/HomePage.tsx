import React from 'react';

import { Button, Page, IPageState } from 'kontur.student.ui';
import { IRouteParams, IRouterService, IRouteActions, RoutesNames } from 'kontur.student.routing';
import { injectProperty } from 'kontur.student.di';

import { IHomeRouteModel } from './HomeRoute';
import { AddProjectSidePage } from '../Project/AddProjectSidePage/AddProjectSidePage';

interface IHomePageState extends IPageState {
  // isProjectSidePageOpened: boolean;
}

export class HomePage<
  P extends IRouteParams = IRouteParams,
  M extends IHomeRouteModel = IHomeRouteModel,
  A extends IRouteActions = IRouteActions,
  S extends IPageState = IHomePageState
> extends Page<IRouteParams, IHomeRouteModel, IRouteActions, IHomePageState> {
  @injectProperty(IRouterService) private readonly routerService!: IRouterService;

  // public state = {
  //   isProjectSidePageOpened: false,
  // };

  private onClickNavigationHandlerGenerator(name: string) {
    return () => {
      this.routerService.navigate(name);
    };
  }

  // private toggleProjectSidePage = () => {
  //   this.setState({ isProjectSidePageOpened: !this.state.isProjectSidePageOpened });
  // };

  public render() {
    return (
      <div>
        {/*{this.state.isProjectSidePageOpened && <AddProjectSidePage onClose={this.toggleProjectSidePage} />}*/}
        Hello from Home Page
        <div>
          <Button onClick={this.onClickNavigationHandlerGenerator(RoutesNames.Projects)}>Projects</Button>
          <Button onClick={this.onClickNavigationHandlerGenerator(RoutesNames.Students)}>Student</Button>
          <Button onClick={this.onClickNavigationHandlerGenerator(RoutesNames.Mentors)}>Mentor</Button>
        </div>
        {/*<div>*/}
        {/*  <Button onClick={this.toggleProjectSidePage}>Добавить проект</Button>*/}
        {/*</div>*/}
        {this.props.children}
      </div>
    );
  }
}
