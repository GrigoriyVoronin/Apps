const NODE_ENV = process.env.NODE_ENV || 'development';
const IS_DEPLOY = process.env.IS_DEPLOY === 'true';
const IS_DEV_SERVER = !!process.env.WEBPACK_DEV_SERVER;
const path = require('path');

const IS_PROD_VERSION = NODE_ENV === 'production';
const IS_FOR_END_USER = IS_DEPLOY || IS_PROD_VERSION;
const BUILD_DIR = path.resolve(__dirname, 'build');
const SCRIPTS_BUILD_DIR = path.relative(BUILD_DIR, path.resolve(BUILD_DIR, 'scripts'));

const ENTRY_NAME = '[name].[fullhash]';
const CHUNK_NAME = IS_FOR_END_USER && !IS_DEV_SERVER ? '[name].[chunkhash]' : '[name]';

const PORT = (process.env.PORT && parseInt(process.env.PORT)) || 4000;

const PLUGINS = require('./webpack/plugins');
const {TS_LOADERS, CSS_LOADERS, FONTS_LOADERS, IMAGES_LOADERS} = require('./webpack/loaders');
const TerserPlugin = require('terser-webpack-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');

const config = {
	mode: IS_PROD_VERSION ? 'production' : 'development',
	devtool: IS_FOR_END_USER ? 'source-map' : IS_DEV_SERVER ? 'eval-cheap-source-map' : 'cheap-source-map',
	target: 'web',
	devServer: {
		allowedHosts: ['localhost'],
		contentBase: BUILD_DIR,
		publicPath: '/',
		port: PORT,
		host: 'localhost',
		compress: true,
		historyApiFallback: true,
		stats: {
			entrypoints: false,
			assets: false,
			children: false,
			chunks: false,
			chunkGroups: false,
			chunkModules: false,
			modules: false,
			version: false,
			maxModules: 0,
		}
	},
	entry: {
		main: ['./index.ts'],
	},
	output: {
		filename: path.join(SCRIPTS_BUILD_DIR, `${ENTRY_NAME}.js`),
		chunkFilename: path.join(SCRIPTS_BUILD_DIR, `${CHUNK_NAME}.js`),
		path: BUILD_DIR,
		publicPath: '/',
		pathinfo: false,
	},
	module: {
		rules: [TS_LOADERS, CSS_LOADERS, FONTS_LOADERS, IMAGES_LOADERS],
	},
	plugins: PLUGINS,
	resolve: {
		modules: ['node_modules'],
		extensions: ['.tsx', '.jsx', '.js', '.ts'],
	},
	stats: {
		chunks: false,
		children: false,
		modules: false,
	},
	watch: false,
	watchOptions: {
		poll: 500,
		ignored: ['/node_modules/', '*.css.d.ts'],
	},
	optimization: {
		moduleIds: 'named',
		usedExports: true,
		sideEffects: true,
		minimizer: IS_FOR_END_USER
			? [
				new TerserPlugin({
					parallel: true,
					extractComments: false,
					terserOptions: {
						output: {
							comments: false,
						},
					},
				}),
				new OptimizeCSSAssetsPlugin({}),
			]
			: undefined,
	},
};

module.exports = config;


