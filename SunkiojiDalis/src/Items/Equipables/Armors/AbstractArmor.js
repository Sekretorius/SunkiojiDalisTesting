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
exports.AbstractArmor = void 0;
var AbstractEquipable_1 = require("../AbstractEquipable");
var AbstractArmor = /** @class */ (function (_super) {
    __extends(AbstractArmor, _super);
    function AbstractArmor(guid, itemData) {
        var _this = _super.call(this, guid, itemData) || this;
        _this.Defense = itemData.defense;
        return _this;
    }
    return AbstractArmor;
}(AbstractEquipable_1.AbstractEquipable));
exports.AbstractArmor = AbstractArmor;
