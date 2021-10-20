import React from 'react';

import styles from './ProjectsPage.css';

import { Page } from 'kontur.student.ui';
import { IRouteParams, IRouterService, RoutesNames, TRouterService } from 'kontur.student.routing';
import { IRouteActions } from 'kontur.student.routing';
import { IPageState, Button } from 'kontur.student.ui';
import { IProjectsListRouteModel } from './ProjectsRoute';
import { injectProperty } from 'kontur.student.di';
import { ProjectSidePage } from '../Project/ProjectSidePage';
import { IAuthorizationService } from 'kontur.student.services';
import type { TAuthorizationService } from 'kontur.student.services';
import { IProjectModel } from '../../domain/models/ProjectModel';
import { AddProjectSidePage } from '../Project/AddProjectSidePage/AddProjectSidePage';

interface IProjectsListState extends IPageState {
  isProjectSidePageOpened: boolean;
  isAddProjectSidePageOpened: boolean;
  currentProject: IProjectModel | undefined;
}

export class ProjectsListPage<
  P extends IRouteParams = IRouteParams,
  M extends IProjectsListRouteModel = IProjectsListRouteModel,
  A extends IRouteActions = IRouteActions,
  S extends IPageState = IProjectsListState
> extends Page<IRouteParams, IProjectsListRouteModel, IRouteActions, IProjectsListState> {
  @injectProperty(IRouterService) private readonly routerService!: TRouterService;
  @injectProperty(IAuthorizationService) private readonly authorizationService!: TAuthorizationService;
  public state = {
    isProjectSidePageOpened: false,
    isAddProjectSidePageOpened: false,
    currentProject: undefined,
  };

  onSwitchProjectSidePage = () => {
    this.setState({ isProjectSidePageOpened: !this.state.isProjectSidePageOpened });
  };

  componentDidMount() {
    this.props.model.id
      ? this.setState({
          currentProject: this.props.model.projects.find((CurrProject) => CurrProject.id === this.props.model.id),
          isProjectSidePageOpened: true,
        })
      : null;
  }

  onSwitchAddProject = () => {
    this.setState({ isAddProjectSidePageOpened: !this.state.isAddProjectSidePageOpened });
  };

  public render() {
    const { projects } = this.props.model;
    const { isProjectSidePageOpened, isAddProjectSidePageOpened, currentProject } = this.state;
    return (
      <div className={styles.projectsPage}>
        <h1 className={styles.projectsTitle}>Проекты</h1>
        {this.authorizationService.hasOpenIdUser() && (
          <Button use={'primary'} className={styles.addProjectButton} onClick={this.onSwitchAddProject}>
            Создать проект
          </Button>
        )}
        {isProjectSidePageOpened && currentProject && (
          <ProjectSidePage project={currentProject} onClose={this.onSwitchProjectSidePage} />
        )}
        {isAddProjectSidePageOpened && <AddProjectSidePage onClose={this.onSwitchAddProject} />}
        {projects &&
          projects.map((project) => (
            <div
              key={project.id}
              className={styles.projectCard}
              onClick={() => {
                this.setState({
                  isProjectSidePageOpened: true,
                  currentProject: projects.find((CurrProject) => CurrProject.id === project.id),
                });
                this.routerService.navigate(RoutesNames.Projects, { id: project.id });
              }}
            >
              <div className={styles.projectCardLeftSide} />
              <div className={styles.projectCardMidSide}>
                <h3>{project.title}</h3>
                <p className={styles.description}>{project.shortDescription}</p>
                <span>Технологии: {project.technologyIds}</span>
              </div>
              <div className={styles.projectCardRightSide}>
                {project.mentorIds.length > 1 ? (
                  <span>
                    Менторы:{' '}
                    {project.mentorIds.map((mentorId) => (
                      <>
                        <a key={mentorId} href="/mentor">
                          {mentorId}
                        </a>{' '}
                        {'\t'}
                      </>
                    ))}
                  </span>
                ) : (
                  <span>
                    {' '}
                    Ментор: <a href="/mentor">{project.mentorIds}</a>
                  </span>
                )}
                <span>{project.technologyIds}</span>
              </div>
            </div>
          ))}
      </div>
    );
  }
}
