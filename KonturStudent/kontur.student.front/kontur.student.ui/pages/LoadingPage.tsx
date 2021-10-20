import React from 'react';
import { Loader } from '@skbkontur/react-ui';
import { injectable } from 'kontur.student.di';

import { IRouteParams, IRouteActions, IRouteBaseActions, IRouterTransition } from 'kontur.student.routing';
import { IPageInstance } from './types';

const BASE_LOADER_STYLES: React.CSSProperties = {
  display: 'flex',
  alignContent: 'center',
  justifyContent: 'center',
  padding: '200px',
  textAlign: 'center',
};

export interface ILoadingPageProps<P extends IRouteParams = IRouteParams, A extends IRouteActions = IRouteActions> {
  transition: IRouterTransition;
  params: P;
  actions: A & IRouteBaseActions;
  children?: IPageInstance;
}

export interface ILoadingPageState {}

export abstract class TLoadingPage {} // для контейнера

@injectable()
export class LoadingPage<
  P extends ILoadingPageProps = ILoadingPageProps,
  S extends ILoadingPageState = ILoadingPageState
> extends React.Component<P, S> {
  render() {
    return (
      <div style={BASE_LOADER_STYLES}>
        <Loader type="big" active />
      </div>
    );
  }
}
