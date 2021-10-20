export abstract class IDateService {
  public abstract fromDateToDatePicker(date: Date | undefined): string;
  public abstract fromDatePikerToDate(date: string): Date;
  public abstract duration(beginDate: Date | undefined, endDate: Date | undefined): string;
  public abstract toDate(date: string | undefined): Date;
}
