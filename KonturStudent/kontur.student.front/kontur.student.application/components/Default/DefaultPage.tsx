import React from 'react';

import { Page, IPageState } from 'kontur.student.ui';
import { IRouteParams, IRouteActions, RoutesNames, IRouterService } from 'kontur.student.routing';

import { IDefaultRouteModel } from './DefaultRoute';
import styles from './DefaultPage.css';
import { injectProperty } from 'kontur.student.di';

export class DefaultPage<
  P extends IRouteParams = IRouteParams,
  M extends IDefaultRouteModel = IDefaultRouteModel,
  A extends IRouteActions = IRouteActions,
  S extends IPageState = IPageState
> extends Page<IRouteParams, IDefaultRouteModel, IPageState> {
  @injectProperty(IRouterService) private readonly routerService!: IRouterService;

  navigateToProjects = (e: any) => {
    if (!e.ctrlKey) {
      e.preventDefault();
    }
    this.routerService.navigate(RoutesNames.Projects);
  };

  public render() {
    return (
      <div className={styles.defaultPage}>
        <div className={styles.bannerContainer}>
          <h1 className={styles.banner}>Менторская программа</h1>
          <span className={styles.text}>
            Набор идет -{' '}
            <a className={styles.link} href={RoutesNames.Projects} onClick={this.navigateToProjects}>
              Перейти к выбору проекта
            </a>
          </span>
        </div>
        <div className={styles.textContainer}>
          <h2 className={styles.secondBanner}>О программе</h2>
          <span className={styles.text}>
            Менторская программа — это совместная работа участника и разработчика над проектом в течение учебного года.
            Участники исследуют метрики или поведение программ, создают приложения, игры и многое другое. Наставник
            подсказывает, как лучше разбить задачу на простые блоки, рекомендует удобные технологии, проводит
            еженедельный код ревью и дает обратную связь.
          </span>
          <span className={styles.text}>
            В таком формате участники получают реальный опыт разработки проекта, видят и заполняют пробелы в своих
            знаниях, понимают, какие задачи им более интересны, а также учатся писать хороший код.
          </span>
        </div>
        <div className={styles.textContainer}>
          <h2 className={styles.secondBanner}>Как стать участником</h2>
          <span className={styles.text}>
            Нужно внимательно прочитать описание{' '}
            <a className={styles.link} href={RoutesNames.Projects} onClick={this.navigateToProjects}>
              проектов
            </a>
            , выбрать те, которые тебе ближе, зарегестрироваться и отправить заявку. Среди анкет менторы выберут
            участников, которые больше всего подходят на реализацию задачи по опыту и мотивации, и пригласят на
            собеседование.
          </span>
          <span className={styles.text}>
            Собеседования пройдут удаленно, либо в офисе компании (в зависимости от обстоятельств). Можно будет
            пообщаться с несколькими менторами по различным проектам и выбрать понравившиеся.
          </span>
          <span className={styles.text}>Итоговое решение принимает ментор, но мы учтем твое мнение :)</span>
        </div>
      </div>
    );
  }
}
