import { IRequestUrlBuilder, OperationType, IRequestHeaders } from './IRequestUrlBuilder';
import { SETTINGS } from '../../../settings/settings';
import { IAuthorizationService } from 'kontur.student.services';
import { inject, LazyServiceIdentifer } from 'kontur.student.di';
import type { TAuthorizationService } from 'kontur.student.services';

export class RequestUrlBuilder extends IRequestUrlBuilder {
  public readonly protocol?: Nullable<string>;
  public readonly hostname?: Nullable<string>;
  public readonly port?: Nullable<number>;
  public readonly namespace?: Nullable<string>;

  constructor(
    @inject(new LazyServiceIdentifer(() => IAuthorizationService))
    private readonly authorizationService: TAuthorizationService
  ) {
    super();

    this.protocol = null;
    this.hostname = null;
    this.port = null;
    this.namespace = '';
  }

  getUrlBase(): string {
    const protocolPrefix = this.getProtocolPrefix();
    const hostname = this.getHostname();
    const portSuffix = this.getPortSuffix(protocolPrefix);
    return SETTINGS.apiBaseUri || protocolPrefix + hostname + portSuffix;
  }

  getHeaders(operation: OperationType, id?: string): IRequestHeaders {
    return {
      authorization: `Bearer ${this.authorizationService.getAccessToken()}`,
    };
  }
  getNamespace(operation: OperationType, id?: string): this['namespace'] {
    return '';
  }
  protected getProtocolPrefix() {
    const protocol = this.protocol || this.getWindowLocation()?.protocol || '';
    return protocol ? `${protocol}//` : '';
  }
  protected getHostname() {
    return this.hostname || this.getWindowLocation()?.hostname || '';
  }
  protected getPortSuffix(protocol: string) {
    const port = this.port || parseInt(this.getWindowLocation()?.port || '', 10);
    return port ? `:${port}` : '';
  }
  private getWindowLocation() {
    return window.location;
  }
}
