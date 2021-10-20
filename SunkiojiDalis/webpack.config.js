const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { webpack } = require("webpack");
module.exports = {
    entry: 
    [
        "./src/index.ts",
        "./src/Characters/Character.ts",
        "./src/Characters/NPC.ts",
        "./src/Characters/FriendlyNpc.ts",
        "./src/Characters/EnemyNpc.ts",
        "./src/Managers/ClientEngine.ts",
        "./src/Managers/NetworkManager.ts"
    ],
    output: {
        path: path.resolve(__dirname, "wwwroot"),
        filename: "[name].[chunkhash].js",
        publicPath: "/"
    },
    resolve: {
        extensions: [".js", ".ts"]
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: "ts-loader"
            },
            {
                test: /\.css$/,
                use: [MiniCssExtractPlugin.loader, "css-loader"]
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin({ cleanOnceBeforeBuildPatterns: [
            '**/*',
            '!resources/**',
        ], }),
        new HtmlWebpackPlugin({
            template: "./src/index.html"
        }),
        new MiniCssExtractPlugin({
            filename: "css/[name].[chunkhash].css"
        })
    ]
};