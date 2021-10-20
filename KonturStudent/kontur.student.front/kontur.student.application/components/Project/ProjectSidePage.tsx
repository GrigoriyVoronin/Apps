import React from 'react';

import styles from './ProjectSidePage.css';

import { SidePage, Button } from 'kontur.student.ui';
import { IProjectModel, ProjectModel } from '../../domain/models/ProjectModel';
import { IRepositoryFactory, observer, TRepositoryFactory } from 'kontur.student.data';
import ProjectBody from './ProjectBody/ProjectBody';
import { injectProperty } from 'kontur.student.di';
import { IAuthorizationService } from 'kontur.student.services';
import type { TAuthorizationService } from 'kontur.student.services';
import ProjectForm from './ProjectForm/ProjectForm';

interface IProjectProps {
  project: IProjectModel | undefined;
  onClose: () => void;
}
interface IProjectState {
  isEditing: boolean;
  isEditingFormValid: boolean;
}

@observer
export class ProjectSidePage extends React.Component<IProjectProps, IProjectState> {
  @injectProperty(IAuthorizationService) private readonly authorizationService!: TAuthorizationService;
  @injectProperty(IRepositoryFactory) protected repositoryFor!: TRepositoryFactory;

  state = {
    isEditing: false,
    isEditingFormValid: true,
  };

  constructor(props: IProjectProps) {
    super(props);
  }

  switchEditing = () => {
    this.setState({ isEditing: !this.state.isEditing });
  };

  onSave = async () => {
    const project = this.props.project;
    if (!project) {
      return;
    }
    try {
      if (!project.isFormValid) {
        this.setState({ isEditingFormValid: false });
        return;
      }
      const res = await this.repositoryFor(ProjectModel).saveRecord(project, project.id);
    } catch (err) {
      console.error(err);
    }
    this.props.onClose();
  };

  onDelete = async () => {
    const project = this.props.project;
    if (!project) {
      return;
    }
    try {
      const res = await this.repositoryFor(ProjectModel).deleteRecord(project);
    } catch (err) {
      console.error(err);
    }
    this.props.onClose();
  };

  public render() {
    const { project, onClose } = this.props;
    const { isEditing, isEditingFormValid } = this.state;
    return project ? (
      <SidePage blockBackground onClose={onClose} width={'45%'}>
        <SidePage.Header className={styles.SidePageTitle}>
          {isEditing ? 'Редактирование проекта' : project.title}
        </SidePage.Header>
        <SidePage.Body className={styles.SidePageBody}>
          {isEditing ? (
            <ProjectForm project={project} isValid={isEditingFormValid} />
          ) : (
            <ProjectBody project={project} />
          )}
        </SidePage.Body>
        <SidePage.Footer panel>
          {this.authorizationService.hasOpenIdUser() ? (
            isEditing ? (
              <div>
                <Button className={styles.FooterButtons} onClick={this.onSave} use={'primary'}>
                  Сохранить проект
                </Button>
                <Button className={styles.FooterButtons} onClick={this.switchEditing}>
                  Отменить
                </Button>
              </div>
            ) : (
              <div className={styles.Footer}>
                <Button use="primary" className={styles.FooterButtons}>
                  Посмотреть кандидатов
                </Button>
                <Button className={styles.FooterButtons} onClick={this.switchEditing}>
                  Редактировать
                </Button>
                <Button use="danger" className={styles.FooterButtons} onClick={this.onDelete}>
                  Удалить
                </Button>
              </div>
            )
          ) : (
            <Button use={'primary'} className={styles.FooterButtons}>
              Подать заявку на участие
            </Button>
          )}
        </SidePage.Footer>
      </SidePage>
    ) : null;
  }
}
