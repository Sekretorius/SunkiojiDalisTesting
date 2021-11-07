"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.ImpassableObstacle = void 0;
var Obstacle_1 = require("./Obstacle");
var ImpassableObstacle = /** @class */ (function (_super) {
    __extends(ImpassableObstacle, _super);
    function ImpassableObstacle(guid, characterData) {
        var _this = _super.call(this, guid, characterData) || this;
        _this.Effect = characterData.effect;
        return _this;
    }
    return ImpassableObstacle;
}(Obstacle_1.Obstacle));
exports.ImpassableObstacle = ImpassableObstacle;
