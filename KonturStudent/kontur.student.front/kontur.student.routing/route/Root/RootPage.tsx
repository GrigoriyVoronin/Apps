import React from 'react';

import { TopBar, Logotype, HelpDot, Gapped, IPageInstance } from 'kontur.student.ui';
import { injectProperty } from 'kontur.student.di';
import { IAuthorizationService } from 'kontur.student.services';

import styles from './RootPage.css';
import { RoutesNames } from '../../RoutesTree';

export interface IRootPageProps {
  ref: React.RefObject<RootPage>;
}
export interface IRootPageState {
  children: Nullable<IPageInstance>;
}

export class RootPage extends React.Component<IRootPageProps, IRootPageState> {
  public state: IRootPageState = { children: null };
  @injectProperty(IAuthorizationService) private readonly authorizationService!: IAuthorizationService;

  public render(): React.ReactNode {
    let name = undefined;
    this.authorizationService.tryLoadOpenIdUser();
    if (this.authorizationService.hasOpenIdUser()) {
      const openIdUser = this.authorizationService.getOpenIdUser();
      name = openIdUser.profile.name;
    }
    return (
      <div className={styles.root}>
        <TopBar>
          <TopBar.Start>
            <TopBar.ItemStatic>
              <Logotype suffix="Студент" color={'#006587'} />
            </TopBar.ItemStatic>
          </TopBar.Start>
          <TopBar.End>
            <TopBar.Item>
              <Gapped gap={8}>
                <HelpDot />
                <a className={styles.about} href={RoutesNames.Default}>
                  Менторская программа
                </a>
              </Gapped>
            </TopBar.Item>
            {this.authorizationService.hasOpenIdUser() && <TopBar.User userName={name!} />}
            <TopBar.Divider />
            {this.authorizationService.hasOpenIdUser() ? (
              <TopBar.Logout onClick={() => this.authorizationService.requestLogout()} />
            ) : (
              <TopBar.Item>
                <div onClick={() => this.authorizationService.authorize()}>Войти</div>
              </TopBar.Item>
            )}
          </TopBar.End>
        </TopBar>
        <div className={styles.layout}>{this.state.children}</div>
      </div>
    );
  }
}
