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
        "./src/Managers/NetworkManager.ts",
        "./src/Obstacles/Obstacle.ts",
        "./src/Obstacles/ImpassableObstacle.ts",
        "./src/Obstacles/PassableObstacle.ts",
        "./src/Items/Item.ts",
        "./src/Items/Equipables/AbstractEquipable.ts",
        "./src/Items/Equipables/Armors/AbstractArmor.ts",
        "./src/Items/Equipables/Armors/ArmorRarities/CommonArmor.ts",
        "./src/Items/Equipables/Armors/ArmorRarities/LegendaryArmor.ts",
        "./src/Items/Equipables/Weapons/AbstractWeapon.ts",
        "./src/Items/Equipables/Weapons/WeaponRarities/CommonWeapon.ts",
        "./src/Items/Equipables/Weapons/WeaponRarities/LegendaryWeapon.ts",
        "./src/Items/Consumables/Foods/AbstractFood.ts",
        "./src/Items/Consumables/Foods/FoodRarities/CommonFood.ts",
        "./src/Items/Consumables/Foods/FoodRarities/LegendaryFood.ts",
        "./src/Items/Consumables/Potions/AbstractPotion.ts",
        "./src/Items/Consumables/Potions/PotionRarities/CommonPotion.ts",
        "./src/Items/Consumables/Potions/PotionRarities/LegendaryPotion.ts",
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