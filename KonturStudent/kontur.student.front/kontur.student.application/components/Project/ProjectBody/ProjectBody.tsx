import React from 'react';

import styles from './ProjectBody.css';

import { observer } from 'kontur.student.data';
import { IProjectModel } from '../../../domain/models/ProjectModel';
import { DateService } from '../../../../services/DateService';

interface IProjectBodyProps {
  project: IProjectModel;
}

@observer
export default class ProjectBody extends React.Component<IProjectBodyProps, any> {
  render() {
    const project = this.props.project;
    return (
      <div>
        <div className={styles.Date}>{DateService.duration(project.beginningDate, project.endDate)}</div>
        <h3 className={styles.SmallTitle}>Идея</h3>
        <div className={styles.ShortDescription}>{project.shortDescription}</div>
        <h3 className={styles.SmallTitle}>Описание</h3>
        <div className={styles.LongDescription}>{project.longDescription}</div>
        <h3 className={styles.SmallTitle}>Технологии</h3>
        <div>{project.technologyIds}</div>
        <h3 className={styles.SmallTitle}>Менторы</h3>
        <div>{project.mentorIds}</div>
      </div>
    );
  }
}
