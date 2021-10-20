import { AxiosError, AxiosResponse } from 'axios';
import { SUCCESSFUL_CODES } from './constants';

export function isAxiosResponse<T>(response: AxiosResponse<T> | AxiosError<T> | Error): response is AxiosResponse<T> {
  return response.hasOwnProperty('status');
}

export function isSuccessfulResponse(code: number) {
  return SUCCESSFUL_CODES.includes(code);
}
