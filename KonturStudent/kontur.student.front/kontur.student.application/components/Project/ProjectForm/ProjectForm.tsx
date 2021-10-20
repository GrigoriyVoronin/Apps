import React from 'react';

import styles from './ProjectForm.css';

import { Textarea, Group, DatePicker } from 'kontur.student.ui';
import { observer } from 'kontur.student.data';
import { IProjectModel } from '../../../domain/models/ProjectModel';

interface IProjectFormProps {
  project: IProjectModel;
  isValid: boolean;
}

@observer
export default class ProjectForm extends React.Component<IProjectFormProps, any> {
  constructor(props: IProjectFormProps) {
    super(props);
  }

  render() {
    const { project, isValid } = this.props;
    return (
      <div className={styles.Form}>
        <span>Наименование</span>
        <Textarea
          value={project.title}
          onValueChange={(value) => project.setTitle(value)}
          width={'100%'}
          rows={1}
          maxRows={1}
          error={!isValid && !project.isTitleValid}
          autoResize
        />
        <span>Даты проведения</span>
        <Group>
          <DatePicker
            value={project.getBeginningDate}
            error={!isValid && !project.isBeginningDateValid}
            onValueChange={(value) => project.setBeginningDate(value)}
          />
          <DatePicker
            value={project.getEndDate}
            error={!isValid && !project.isEndDateValid}
            onValueChange={(value) => project.setEndDate(value)}
          />
        </Group>
        <span className={styles.BodyItem}>Идея(кратко)</span>
        <Textarea
          value={project.shortDescription}
          onValueChange={(value) => project.setShortDescription(value)}
          width={'100%'}
          rows={2}
          error={!isValid && !project.isShortDescriptionValid}
          autoResize
        />
        <span>Описание</span>
        <Textarea
          value={project.longDescription ? project.longDescription : ''}
          onValueChange={(value) => project.setLongDescription(value)}
          width={'100%'}
          rows={5}
          autoResize
        />
      </div>
    );
  }
}
