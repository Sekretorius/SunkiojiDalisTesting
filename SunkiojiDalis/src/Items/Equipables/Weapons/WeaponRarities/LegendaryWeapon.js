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
exports.LegendaryWeapon = void 0;
var AbstractWeapon_1 = require("../AbstractWeapon");
var LegendaryWeapon = /** @class */ (function (_super) {
    __extends(LegendaryWeapon, _super);
    function LegendaryWeapon(guid, itemData) {
        var _this = _super.call(this, guid, itemData) || this;
        _this.BelongsTo = -1;
        return _this;
    }
    return LegendaryWeapon;
}(AbstractWeapon_1.AbstractWeapon));
exports.LegendaryWeapon = LegendaryWeapon;
