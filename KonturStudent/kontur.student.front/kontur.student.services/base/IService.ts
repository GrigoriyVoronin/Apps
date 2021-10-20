import { injectable } from 'kontur.student.di';

@injectable()
export abstract class IService {
  public abstract async start(): Promise<any>;
  public abstract async stop(): Promise<any>;
}
