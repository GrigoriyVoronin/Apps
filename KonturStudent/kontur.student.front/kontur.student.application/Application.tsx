import React from 'react';
import ReactDOM from 'react-dom';
import { ApplicationPage } from './components/ApplicationPage';

import { IRouterService } from 'kontur.student.routing';
import { ContainerConfiguration, injectArguments } from 'kontur.student.di';
import { injectProperty } from 'kontur.student.di';
import { IAuthorizationService, ILoggerService } from 'kontur.student.services';
import { FLAT_THEME, ThemeContext } from '@skbkontur/react-ui';

export class Application {
  @injectProperty(ILoggerService) private readonly loggerService!: ILoggerService;
  @injectProperty(IAuthorizationService) private readonly authorizationService!: IAuthorizationService;
  @injectProperty(IRouterService) private readonly routerService!: IRouterService;

  async start() {
    ContainerConfiguration.init();
    await this.startServices();
    return ReactDOM.render(
      <ThemeContext.Provider value={FLAT_THEME}>
        <ApplicationPage children={this.routerService.getRootPage()} />
      </ThemeContext.Provider>,
      document.getElementById('ApplicationRoot')
    );
  }

  private async startServices() {
    await Promise.all([this.routerService.start(), this.loggerService.start(), this.authorizationService.start()]);
  }
}
