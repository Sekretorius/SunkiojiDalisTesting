"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Item = void 0;
var Item = /** @class */ (function () {
    function Item(guid, itemData) {
        this.guid = guid;
        this.Id = itemData.id;
        this.Sprite = itemData.sprite;
        this.Name = itemData.name;
        this.Weight = itemData.weight;
        this.Quantity = itemData.quantity;
        this.X = itemData.x;
        this.Y = itemData.y;
        this.BelongsTo = itemData.belongsTo;
    }
    return Item;
}());
exports.Item = Item;
