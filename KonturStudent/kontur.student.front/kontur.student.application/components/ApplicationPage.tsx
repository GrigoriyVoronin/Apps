import React from 'react';
import styles from './ApplicationPage.css';

interface IPageProps {}
interface IPageState {}

export class ApplicationPage extends React.Component<IPageProps, IPageState> {
  public render() {
    return <div className={styles.applicationPage}>{this.props.children}</div>;
  }
}
