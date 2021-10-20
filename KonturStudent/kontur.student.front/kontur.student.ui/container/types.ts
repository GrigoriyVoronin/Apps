import { TPage, TLoadingPage, TErrorPage } from '../pages/types';

export interface IUiLayerSettings {
  pageClass: TPage;
  loadingPageClass: TLoadingPage;
  errorPageClass: TErrorPage;
}
