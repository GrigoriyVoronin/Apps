import { ModelTypeFactory, DateTimeUTCCustomType } from 'kontur.student.data';
import { types, Instance, SnapshotIn, SnapshotOut } from 'mobx-state-tree';
import { DateService } from '../../../services/DateService';

const ProjectContract = types
  .model({
    id: types.maybe(types.identifier),
    title: types.string,
    longDescription: types.maybeNull(types.string),
    shortDescription: types.string,
    mentorIds: types.optional(types.array(types.string), []),
    technologyIds: types.optional(types.array(types.string), []),
    beginningDate: DateTimeUTCCustomType(),
    endDate: DateTimeUTCCustomType(),
    results: types.maybeNull(types.string),
  })
  .actions((self) => ({
    setTitle(newTitle: string) {
      self.title = newTitle;
    },

    setLongDescription(newLongDescription: string) {
      self.longDescription = newLongDescription;
    },

    setShortDescription(newShortDescription: string) {
      self.shortDescription = newShortDescription;
    },

    setBeginningDate(newBeginningDate: string) {
      self.beginningDate = DateService.fromDatePikerToDate(newBeginningDate);
    },

    setEndDate(newEndDate: string) {
      self.endDate = DateService.fromDatePikerToDate(newEndDate);
    },
  }))
  .views((self) => ({
    get isTitleValid() {
      return self.title !== '';
    },

    get isShortDescriptionValid() {
      return self.shortDescription !== '';
    },

    get isBeginningDateValid() {
      return self.beginningDate !== undefined;
    },

    get isEndDateValid() {
      return self.endDate !== undefined;
    },

    get isFormValid() {
      return (
        self.title !== '' &&
        self.shortDescription !== '' &&
        self.beginningDate !== undefined &&
        self.endDate !== undefined
      );
    },

    get getBeginningDate() {
      return DateService.fromDateToDatePicker(self.beginningDate);
    },

    get getEndDate() {
      return DateService.fromDateToDatePicker(self.endDate);
    },
  }));

export const ProjectModel = ModelTypeFactory.create(ProjectContract, 'projects');

type ProjectModelType = typeof ProjectModel;
export interface TProjectModelType extends ProjectModelType {}
export interface IProjectModel extends Instance<TProjectModelType> {}
export interface IProjectModelCreate extends SnapshotIn<TProjectModelType> {}
export interface IProjectModelSnapshot extends SnapshotOut<TProjectModelType> {}
