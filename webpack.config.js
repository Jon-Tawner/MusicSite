const { VueLoaderPlugin } = require("vue-loader");
const path = require('path');

module.exports = {
  mode: 'development',
  entry: './src/main.mjs',
  output: {
    path: path.resolve(__dirname, 'wwwroot'),
    filename: 'bundle.js',
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: 'vue-loader',
      },
      {
        test: /\.css$/,
        use: ['style-loader', 'css-loader'],
      }
    ],
  },
  plugins: [new VueLoaderPlugin()],

  resolve: {
    alias: {
      vue: 'vue/dist/vue.esm-bundler.js',
    },
    extensions: ['.js', '.mjs', '.vue'],
  },
  devServer: {
    static: {
      directory: path.join(__dirname, 'wwwroot'),
    },
    hot: true,
    port: 8080,
  },
};
