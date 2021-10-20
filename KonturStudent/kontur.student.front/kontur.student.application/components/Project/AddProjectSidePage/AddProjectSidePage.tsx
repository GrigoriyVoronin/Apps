import React from 'react';

import styles from '../ProjectSidePage.css';

import { SidePage, Button } from 'kontur.student.ui';
import { injectProperty } from 'kontur.student.di';
import { IRepositoryFactory, TRepositoryFactory } from 'kontur.student.data';
import { IProjectModel, ProjectModel } from '../../../domain/models/ProjectModel';
import ProjectForm from '../ProjectForm/ProjectForm';

interface IAddProjectSidePageProps {
  onClose: () => void;
}

interface IAddProjectSidePageState {
  isFormValid: boolean;
}

export class AddProjectSidePage extends React.Component<IAddProjectSidePageProps, IAddProjectSidePageState> {
  @injectProperty(IRepositoryFactory) protected repositoryFor!: TRepositoryFactory;
  private readonly project: IProjectModel;

  constructor(props: IAddProjectSidePageProps) {
    super(props);
    this.state = {
      isFormValid: true,
    };
    this.project = this.repositoryFor(ProjectModel).createDetachedFromPayload({
      title: '',
      longDescription: undefined,
      shortDescription: '',
      mentorIds: [],
      technologyIds: [],
      beginningDate: new Date().toISOString(),
      endDate: new Date().toISOString(),
      results: undefined,
    });
  }

  private onSave = async (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
    try {
      if (!this.project.isFormValid) {
        this.setState({ isFormValid: false });
        return;
      }
      const res = this.repositoryFor(ProjectModel).createRecordFromPayload(this.project.getSnapshot());
    } catch (err) {
      console.log(err);
    }
    this.props.onClose();
  };

  render() {
    return (
      <SidePage onClose={this.props.onClose} width={'45%'} blockBackground>
        <SidePage.Header className={styles.Title}>Создание нового проекта</SidePage.Header>
        <SidePage.Body className={styles.SidePageBody}>
          <ProjectForm project={this.project} isValid={this.state.isFormValid} />
        </SidePage.Body>
        <SidePage.Footer panel>
          <Button className={styles.FooterButtons} onClick={this.onSave} use={'primary'}>
            Создать проект
          </Button>
          <Button className={styles.FooterButtons} onClick={this.props.onClose}>
            Отменить
          </Button>
        </SidePage.Footer>
      </SidePage>
    );
  }
}
