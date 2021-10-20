export interface IUrlParamsShape {
  [key: string]: string;
}

export interface IObjectQueryParams {
  [key: string]: undefined | string | string[] | IObjectQueryParams | IObjectQueryParams[];
}
