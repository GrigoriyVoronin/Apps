module.exports = api => {
  const isTest = api.env() === 'test';

  const presets = [
    [
      '@babel/preset-env',
      {
        loose: true, // NOTE: loose implementations are usually smaller/faster + it excludes evil typeof Symbol transform
        modules: false, // NOTE: webpack handles modules

        /* NOTE: this is runtime polyfilling (relies on browserlist):
         - can be used with 'entry' and implicit core-js import at entry point;
         - can be used with 'usage' to omit any imports at all.

         We do not transpile node_modules so we do not have no full control over the usages, but for now we trust in the libraries we use.
         If any not-well-transpiled library is found we could include it in babel-loader or switch to 'entry' option.
        */
        useBuiltIns: 'usage',
        corejs: { version: 3 },
      },
    ],
    ['@babel/preset-react'],
    ['@babel/preset-typescript'],
  ];

  const plugins = [
    ['babel-plugin-transform-typescript-metadata'],
    ['@babel/plugin-proposal-decorators', { legacy: true }],
    ['@babel/plugin-proposal-class-properties', { loose: true }],
    ['@babel/plugin-proposal-object-rest-spread', { loose: false }],
    ['@babel/plugin-transform-react-constant-elements']
  ];

  plugins.push(
    [
      '@babel/plugin-transform-runtime',
      {
        corejs: false, // NOTE: because it does not respect browserlist and ponyfills all built-ins (i.e. Map/Set which breaks mobx and others), see preset-env
        helpers: true, // NOTE: to minify bundle size by extracting common helpers, '@babel/runtime' is installed to make things work
        regenerator: true, // NOTE: automatically imports regenerator (can be omitted at entry point), '@babel/runtime' is installed to make things work
        useESModules: !isTest, // NOTE: those are handled by webpack well, but not by jest
      },
    ],
    ['@babel/plugin-transform-block-scoping']
  );

  return { presets, plugins };
};
