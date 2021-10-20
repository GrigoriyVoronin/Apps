import { TAddContainerModuleDelegate } from 'kontur.student.di';
import { IUiLayerSettings } from './types';
import { TPage } from '../pages/Page';
import { TLoadingPage } from '../pages/LoadingPage';
import { TErrorPage } from '../pages/ErrorPage';

export const getUILayerModuleDelegate = (settings: IUiLayerSettings): TAddContainerModuleDelegate => {
  return function (bind) {
    bind(TPage).toConstructor(settings.pageClass);
    bind(TLoadingPage).toConstructor(settings.loadingPageClass);
    bind(TErrorPage).toConstructor(settings.errorPageClass);
  };
};
