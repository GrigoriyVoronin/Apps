const webpack = require('webpack');
const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

const NODE_ENV = process.env.NODE_ENV || 'development';
const IS_DEPLOY = process.env.IS_DEPLOY === 'true';
const IS_DEV_SERVER = !!process.env.WEBPACK_DEV_SERVER;

const IS_PROD_VERSION = NODE_ENV === 'production';
const IS_FOR_END_USER = IS_DEPLOY || IS_PROD_VERSION;
const FILE_NAME = IS_FOR_END_USER && !IS_DEV_SERVER ? '[name].[contenthash]' : '[name]';
const BUILD_DIR = path.resolve(__dirname, '..', 'build');
const SCRIPTS_BUILD_DIR = path.relative(BUILD_DIR, path.resolve(BUILD_DIR, 'scripts'));
const STYLES_BUILD_DIR = path.relative(BUILD_DIR, path.resolve(BUILD_DIR, 'styles'));

const PLUGINS = [
	new webpack.DefinePlugin({
		'process.env.NODE_ENV': JSON.stringify(NODE_ENV),
		'process.env.IS_DEPLOY': JSON.stringify(IS_DEPLOY),
	}),
	new MiniCssExtractPlugin({
		filename: path.join(STYLES_BUILD_DIR, `${FILE_NAME}.css`),
		chunkFilename: path.join(STYLES_BUILD_DIR, `${FILE_NAME}.css`),
		ignoreOrder: true,
	}),
	new webpack.ProvidePlugin({
		process: 'process/browser',
	}),
];

if (!IS_DEPLOY) {
	PLUGINS.unshift(
		new CleanWebpackPlugin({
			dry: false,
			dangerouslyAllowCleanPatternsOutsideProject: true,
			cleanOnceBeforeBuildPatterns: [SCRIPTS_BUILD_DIR, STYLES_BUILD_DIR,],
		})
	);
	PLUGINS.push(
		// TODO: plugin should be updated, since a build result has the  DeprecationWarning: Compilation.assets will be frozen in future, all modifications are deprecated.
		// NOTE: related issue: https://github.com/jantimon/html-webpack-plugin/issues/1529
		new HtmlWebpackPlugin({
			filename: path.join(BUILD_DIR, 'index.html'),
			template: path.join(__dirname, '..', 'index.html'),
			chunksSortMode: 'none',
		})
	);
}

module.exports = PLUGINS;
