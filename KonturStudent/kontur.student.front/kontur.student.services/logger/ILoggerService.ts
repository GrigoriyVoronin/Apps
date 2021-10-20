import { IService } from '..';

export abstract class ILoggerService extends IService {
  public abstract log(...args: any[]): void;
  public abstract warn(): void;
  public abstract error(): void;
}
