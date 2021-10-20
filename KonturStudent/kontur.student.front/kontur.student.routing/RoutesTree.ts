import { IRoute } from './route/IRoute';
import { IRouteClassGetter } from './container/types';
import { Route } from 'router5';

export interface IRouteNode extends Route {
  name: string;
  path: string;
  routeClass: IRouteClassGetter;
  routeInstance?: IRoute;
}

export enum RoutesNames {
  Default = 'default',
  Home = 'home',
  Projects = 'projects',
  ProjectId = 'projects.project',
  ProjectsList = 'projects.list',
  Students = 'students',
  Mentors = 'mentors',
  LoginCallback = 'login-callback',
  LogoutCallback = 'logout-callback',
}

export const RoutesTree: IRouteNode[] = [
  {
    name: RoutesNames.Default,
    path: '/',
    routeClass: async () =>
      (await import(/* webpackChunkName: "default" */ /* webpackPreload: true */ 'kontur.student.application'))
        .DefaultRoute,
  },
  {
    name: RoutesNames.Home,
    path: '/home',
    routeClass: async () =>
      (await import(/* webpackChunkName: "home" */ /* webpackPreload: true */ 'kontur.student.application')).HomeRoute,
  },
  {
    name: RoutesNames.Students,
    path: '/students',
    routeClass: async () =>
      (
        await import(
          /* webpackChunkName: "students" */
          'kontur.student.application'
        )
      ).StudentsRoute,
  },
  {
    name: RoutesNames.Mentors,
    path: '/mentors',
    routeClass: async () =>
      (
        await import(
          /* webpackChunkName: "mentors" */
          'kontur.student.application'
        )
      ).MentorsRoute,
  },
  {
    name: RoutesNames.Projects,
    path: '/projects',
    routeClass: async () =>
      (await import(/* webpackChunkName: "projects" */ /* webpackPreload: true */ 'kontur.student.application'))
        .ProjectsRoute,
  },
  {
    name: RoutesNames.LoginCallback,
    path: '/login-callback',
    routeClass: async () =>
      (
        await import(
          /* webpackChunkName: "login-callback" */
          'kontur.student.application'
        )
      ).LoginCallbackRoute,
  },
  {
    name: RoutesNames.LogoutCallback,
    path: '/logout-callback',
    routeClass: async () =>
      (
        await import(
          /* webpackChunkName: "logout-callback" */
          'kontur.student.application'
        )
      ).LogoutCallbackRoute,
  },
];

export const defaultRoute: string = RoutesNames.Default;
