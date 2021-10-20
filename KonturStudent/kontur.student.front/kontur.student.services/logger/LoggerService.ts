import { IService } from '../base/IService';
import { ILoggerService } from './ILoggerService';

export class LoggerService extends IService implements ILoggerService {
  error(): void {}

  log(...args: any[]): void {
    return console.log(...args);
  }

  async start() {
    return null;
  }

  async stop() {
    return null;
  }

  warn(): void {}
}
