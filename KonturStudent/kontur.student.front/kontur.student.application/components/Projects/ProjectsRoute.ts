import { IRouterTransition, Route } from 'kontur.student.routing';

import { ProjectsListPage } from './ProjectsPage';
import { IRouterState } from 'kontur.student.routing/route/types';
import { IProjectModel, ProjectModel } from '../../domain/models/ProjectModel';

export interface IProjectsListRouteParams {
  id: string;
}

export interface IProjectsListRouteModel {
  projects: IProjectModel[];
  id: string | null;
}

export class ProjectsRoute extends Route<IProjectsListRouteParams, IProjectsListRouteModel> {
  readonly pageClass = ProjectsListPage;

  public async model(params: IProjectsListRouteParams): Promise<IProjectsListRouteModel> {
    const projects = await this.repositoryFor(ProjectModel).findAll();
    const id = params.id ? params.id : null;
    return { projects, id };
  }

  canDeactivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }

  canActivate(toState: IRouterState, fromState: IRouterState): Promise<boolean> | boolean {
    return true;
  }
}
