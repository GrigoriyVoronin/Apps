import { constants, errorCodes } from 'router5';

export const RouterConstants = Object.assign({}, constants);

export const RouterErrorCodes = Object.assign({}, errorCodes, {
  JS_ERROR: 'JS_ERROR',
});
