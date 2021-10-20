import { IService } from 'kontur.student.services';
import { IDateService } from './IDateService';
import { format, parse } from 'date-fns';
import { ru } from 'date-fns/locale';
// NOTE: вынесен из воркспейса, потому что используется в моделях, код которых исполняется раньше, чем заполняется контейнер
export class DateService {
  async start() {
    return null;
  }

  async stop() {
    return null;
  }

  public static UTC_DATE_TIME_REGEXP = /\d{4}-[01]\d-[0-3]\dT[0-2]\d:[0-5]\d:[0-5]\d(\.\d+([+-][0-2]\d:[0-5]\d|Z))?/;

  static duration = (beginDate: Date | undefined, endDate: Date | undefined) => {
    return endDate && beginDate
      ? `${format(beginDate, 'dd LLLL yyyy', { locale: ru })} — ${format(endDate, 'dd LLLL yyyy', { locale: ru })} `
      : beginDate
      ? `c ${format(beginDate, 'dd LLLL yyyy', { locale: ru })}`
      : 'Не указано';
  };

  static fromDateToDatePicker = (date: Date | null) => {
    return date ? format(date, 'dd.MM.yyyy', { locale: ru }) : '';
  };

  static toDate = (date: string | null) => {
    return date ? new Date(Date.parse(date)) : new Date();
  };

  static fromDatePikerToDate = (date: string) => {
    return date ? parse(date, 'dd.MM.yyyy', new Date()) : new Date();
  };
}
