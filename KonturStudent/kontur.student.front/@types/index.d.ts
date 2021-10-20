declare module '*.png';
declare module '*.jpg';

declare module '*.svg' {
  const content: any;
  export default content;
}

declare module '*.css' {
  const classes: { [key: string]: string };
  export default classes;
}

declare type JSPrimitiveType = string | number | boolean;
declare type NoneType = null | undefined;
declare type MaybeMissingStringType = string | NoneType;
declare type MaybeMissingIdType = string | number | NoneType;
declare type IMaybeDate = Date | string | number;
declare type IDateOrTimestamp = Date | number;
declare type ITypedArray =
  | Int8Array
  | Uint8Array
  | Int16Array
  | Uint16Array
  | Int32Array
  | Uint32Array
  | Uint8ClampedArray
  | Float32Array
  | Float64Array;
declare type Nullable<T> = T | null;
declare type MaybeMissing<T> = T | null | undefined;
declare type MaybePromise<T> = T | Promise<T>;
declare type EnumValuesType<E> = E[keyof E];
declare type Writeable<T> = { -readonly [K in keyof T]: T[K] };
declare type StringKeyedObject<T extends any = any> = { [key: string]: T };
declare type RequireAtLeastOneKey<T, Keys extends keyof T = keyof T> = Omit<T, Keys> &
  { [K in Keys]-?: Required<Pick<T, K>> }[Keys];
declare type MakeOptional<INPUT, Keys extends keyof INPUT = keyof INPUT> = Omit<INPUT, Keys> &
  { [key in Keys]+?: INPUT[key] };
declare type Override<INPUT, OVERRIDES extends Record<string, any>> = Omit<INPUT, keyof OVERRIDES> & OVERRIDES;
declare type RemoveUndefined<T> = undefined extends T ? Exclude<T, undefined> : T;
declare type RemoveUndefinedFromValues<T> = { [K in keyof T]: RemoveUndefined<T[K]> };
declare type Ctor<T> = new (...args: any[]) => T;
