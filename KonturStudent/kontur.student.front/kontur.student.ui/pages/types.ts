import React from 'react';

import { IRouteParams, IRouteActions } from 'kontur.student.routing';
import type { IPageProps } from './Page';
import type { ILoadingPageProps } from './LoadingPage';
import type { IErrorPageProps } from './ErrorPage';
import { Page } from './Page';
import { LoadingPage } from './LoadingPage';
import { ErrorPage } from './ErrorPage';

export interface IPageProviderInstance<P, M, A> {}

export type IPageInstance<P = IRouteParams, M = undefined, A extends IRouteActions = IRouteActions> =
  | IPageProviderInstance<P, M, A>
  | React.ReactElement<IPageProps<P, M, A>>
  | React.ReactElement<Partial<ILoadingPageProps>>
  | React.ReactElement<Partial<IErrorPageProps>>
  | null;

export type TPage = Ctor<Page>;
export type TLoadingPage = Ctor<LoadingPage>;
export type TErrorPage = Ctor<ErrorPage>;
