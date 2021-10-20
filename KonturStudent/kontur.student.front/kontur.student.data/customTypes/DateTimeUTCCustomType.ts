import { IType, types } from 'mobx-state-tree';
import { DateService } from '../../services/DateService';

const DATE_TIME_UTC_TYPE_NAME = 'DateTimeUTC';

export function DateTimeUTCCustomType(): IType<string | Date, string, Date> {
  return types.custom<string, Date>({
    name: DATE_TIME_UTC_TYPE_NAME,

    fromSnapshot(value: string) {
      return new Date(value);
    },
    toSnapshot(value: Date) {
      return value.toISOString();
    },
    isTargetType(value: string | Date): boolean {
      return value instanceof Date;
    },
    getValidationMessage(value: string): string {
      if (DateService.UTC_DATE_TIME_REGEXP.test(value)) {
        return '';
      }
      return `'${value}' doesn't look like date`;
    },
  });
}
