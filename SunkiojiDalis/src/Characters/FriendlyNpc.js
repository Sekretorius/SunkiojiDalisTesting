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
exports.FriendlyNpc = void 0;
var NPC_1 = require("./NPC");
var FriendlyNpc = /** @class */ (function (_super) {
    __extends(FriendlyNpc, _super);
    function FriendlyNpc(guid, characterData) {
        return _super.call(this, guid, characterData) || this;
    }
    FriendlyNpc.prototype.GetAttackAlgorithm = function () {
        //maybe use this for visual showing
    };
    FriendlyNpc.prototype.GetMoveAlgorithm = function () {
        //maybe use this for visual showing
    };
    FriendlyNpc.prototype.SetAttackAlgorithm = function () {
        //maybe use this for visual showing
    };
    FriendlyNpc.prototype.SetMoveAlgorithm = function () {
        //maybe use this for visual showing
    };
    FriendlyNpc.prototype.Attack = function () {
    };
    FriendlyNpc.prototype.Move = function () {
    };
    FriendlyNpc.prototype.Die = function () {
    };
    return FriendlyNpc;
}(NPC_1.NPC));
exports.FriendlyNpc = FriendlyNpc;
