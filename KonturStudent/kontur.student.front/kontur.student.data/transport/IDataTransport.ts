import { AxiosRequestConfig, AxiosResponse } from 'axios';

export abstract class IDataTransport {
  abstract getUri(config?: AxiosRequestConfig): string;
  abstract request<T = any>(config: AxiosRequestConfig): Promise<AxiosResponse<T>>;
  abstract get<T = any>(url: string, config?: AxiosRequestConfig): Promise<AxiosResponse<T>>;
  abstract post<T, R = any>(url: string, data?: T, config?: AxiosRequestConfig): Promise<AxiosResponse<R>>;
  abstract put<T, R = any>(url: string, data?: T, config?: AxiosRequestConfig): Promise<AxiosResponse<R>>;
  abstract patch<T = any>(url: string, data?: any, config?: AxiosRequestConfig): Promise<AxiosResponse<T>>;
  abstract delete<R = any>(url: string, config?: AxiosRequestConfig): Promise<AxiosResponse<R>>;
  abstract head<R = any>(url: string, config?: AxiosRequestConfig): Promise<AxiosResponse<R>>;
}
