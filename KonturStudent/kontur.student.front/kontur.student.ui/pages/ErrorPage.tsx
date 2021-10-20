import React from 'react';
import { injectable } from 'kontur.student.di';

import type { IRouteParams } from 'kontur.student.routing';
import { IRouteActions, IRouteBaseActions, IRouterTransition } from 'kontur.student.routing';
import { IPageInstance } from './types';
import { RouterErrorCodes } from 'kontur.student.routing';

export interface IPageError extends Error {
  code: string;
  path?: string;
}

export interface IErrorPageProps<P extends IRouteParams = IRouteParams, A extends IRouteActions = IRouteActions> {
  error: IPageError;
  transition?: Nullable<IRouterTransition>;
  params?: P;
  actions?: A & IRouteBaseActions;
  children?: IPageInstance;
  onRetry?(): void;
  onRetryCaption?: string;
}

export abstract class TErrorPage {} //для контейнера

@injectable()
export class ErrorPage<
  P extends IRouteParams = IRouteParams,
  A extends IRouteActions = IRouteActions
> extends React.Component<IErrorPageProps<P, A>> {
  render() {
    return (
      <div>
        {this.renderSummary()}
        {this.renderDescription()}
      </div>
    );
  }

  private renderSummary() {
    const code = this.props.error.code;
    let errorCaption: React.ReactNode;
    let errorCode: React.ReactNode;
    switch (code) {
      case RouterErrorCodes.ROUTE_NOT_FOUND: {
        errorCaption = 'Страница не найдена';
        errorCode = '404';
        break;
      }
      case RouterErrorCodes.JS_ERROR: {
        errorCaption = 'Неизвестная ошибка ';
        errorCode = null;
        break;
      }
      default: {
        errorCaption = 'Неизвестная ошибка';
        errorCode = code;
        break;
      }
    }

    return (
      <h2>
        {errorCaption}
        {errorCode ? <span> ({errorCode})</span> : null}
      </h2>
    );
  }

  private renderDescription() {
    const code = this.props.error.code;
    const path = this.props.error.path;
    let errorDescription: React.ReactNode;
    switch (code) {
      case RouterErrorCodes.ROUTE_NOT_FOUND: {
        errorDescription = (
          <span>
            {path && `По пути ${path} ничего не найдено.`}
            {path && <br />}
            Попробуйте начать с главной
          </span>
        );
        break;
      }
      case RouterErrorCodes.JS_ERROR: {
        errorDescription = this.props.error.message;
        break;
      }
      default: {
        errorDescription = null;
        break;
      }
    }

    return <div>{errorDescription}</div>;
  }
}
