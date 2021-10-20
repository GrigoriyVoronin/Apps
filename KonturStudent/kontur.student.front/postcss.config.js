// NOTE: this config is purely for "typescript language service -> typescript-plugin-css-modules" plugin
// It helps to generate virtual css declarations with imported class names and @value's

module.exports = {
  plugins: [
    require('postcss-import-sync2')(),
    require('postcss-modules-values'),
    require('postcss-nested')({ preserveEmpty: true }),
  ],
};
