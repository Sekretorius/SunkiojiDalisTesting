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
exports.AbstractEquipable = void 0;
var Item_1 = require("../Item");
var AbstractEquipable = /** @class */ (function (_super) {
    __extends(AbstractEquipable, _super);
    function AbstractEquipable(guid, itemData) {
        return _super.call(this, guid, itemData) || this;
    }
    AbstractEquipable.prototype.Equip = function () {
        return 0;
    };
    AbstractEquipable.prototype.Unequip = function () {
        return 0;
    };
    return AbstractEquipable;
}(Item_1.Item));
exports.AbstractEquipable = AbstractEquipable;
