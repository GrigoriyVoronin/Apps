const NODE_ENV = process.env.NODE_ENV || 'development';
const IS_DEPLOY = process.env.IS_DEPLOY === 'true';
const IS_DEV_SERVER = !!process.env.WEBPACK_DEV_SERVER;
const IS_PROD_VERSION = NODE_ENV === 'production';
const path = require('path');

const BUILD_DIR = path.resolve(__dirname, '..', 'build');
const FONTS_BUILD_DIR = path.relative(BUILD_DIR, path.resolve(BUILD_DIR, 'fonts'));
const IMAGES_BUILD_DIR = path.relative(BUILD_DIR, path.resolve(BUILD_DIR, 'images'));

const APPLICATION_DIR = path.resolve(__dirname, 'kontur.student.application');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const TS_LOADERS = {
	test: /\.tsx?$/,
	//include: [APPLICATION_DIR],
	exclude: [/node_modules/],
	use: [
		{
			loader: 'babel-loader',
			options: {
				babelrc: false,
				cacheDirectory: !IS_DEPLOY,
				configFile: path.resolve(__dirname, '..', 'babel.config.js'),
			},
		},
	],
};

const CSS_LOADERS = {
	test: /\.css$/,
	use: [
		{
			loader: MiniCssExtractPlugin.loader,
		},
		{
			loader: 'css-loader',
			options: {
				modules: {
					mode: 'local',
					localIdentName: IS_PROD_VERSION ? '[local]-[hash:base64:4]' : '[name]-[local]-[hash:base64:4]', //TODO: https://github.com/webpack-contrib/css-loader/issues/406,
					exportLocalsConvention: 'camelCase',
				},
				import: false,
			},
		},
		{
			loader: 'postcss-loader',
		},
	],
};

const FONTS_LOADERS = {
	test:  /\.(woff|woff2|eot|ttf|otf)$/,
	use: [
		{
			loader: 'file-loader',
			options: {
				name: `[name].[contenthash].[ext]`,
				outputPath: FONTS_BUILD_DIR,
			  }
		}
	]
};

const IMAGES_LOADERS = {
	test:  /\.(png|bmp|svg|jpe?g|gif)$/,
	use: [
		{
			loader: 'file-loader',
			options: {
				name: `[name].[contenthash].[ext]`,
				outputPath: IMAGES_BUILD_DIR,
			  }
		}
	]
};


module.exports = { TS_LOADERS, CSS_LOADERS, FONTS_LOADERS, IMAGES_LOADERS };
