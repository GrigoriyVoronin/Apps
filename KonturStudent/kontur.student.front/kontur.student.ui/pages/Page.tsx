import React from 'react';
import { injectable } from 'kontur.student.di';

import { IRouteParams, IRouteActions } from 'kontur.student.routing';

export interface IPageProps<P, M, A> {
  params: P;
  model: M;
  actions: A;
}

export interface IPageState {}

export abstract class TPage {} // абстрактный класс для DI контейнера
@injectable()
export class Page<
  P extends IRouteParams = IRouteParams,
  M extends any = undefined, // интерфейс модели, которая прокинется роутом через пропсы
  A extends IRouteActions = IRouteActions,
  S extends IPageState = IPageState
> extends React.Component<IPageProps<P, M, A>, S> {
  public state = {} as S;

  public render() {
    return <React.Fragment>{this.props.children}</React.Fragment>;
  }
}
