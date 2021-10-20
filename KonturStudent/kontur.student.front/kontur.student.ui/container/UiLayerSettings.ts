import { IUiLayerSettings } from './types';

import { Page } from '../pages/Page';
import { ErrorPage } from '../pages/ErrorPage';
import { LoadingPage } from '../pages/LoadingPage';

export const UiLayerSettings: IUiLayerSettings = {
  pageClass: Page,
  loadingPageClass: LoadingPage,
  errorPageClass: ErrorPage,
};
