"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Vector2D = void 0;
var Vector2D = /** @class */ (function () {
    function Vector2D(x, y) {
        this.x = x;
        this.y = y;
    }
    Vector2D.prototype.GetMagnidute = function () {
        return Math.sqrt(Math.pow(this.x, 2) + Math.pow(this.y, 2));
    };
    Vector2D.prototype.Normalize = function () {
        var magnitude = this.GetMagnidute();
        return new Vector2D(this.x / magnitude, this.y / magnitude);
    };
    Vector2D.prototype.DirectionTo = function (to) {
        return Vector2D.Subtract(to, this);
    };
    Vector2D.Lerp = function (origin, target, t) {
        var direction = origin.DirectionTo(target);
        return new Vector2D(origin.x + direction.x * t, origin.y + direction.y * t);
    };
    Vector2D.ProjectOn = function (vector, prjectionVector) {
        var normaizedV = prjectionVector.Normalize();
        var dotProduct = Vector2D.DotProduct(vector, normaizedV);
        return Vector2D.Multiply(normaizedV, dotProduct);
    };
    Vector2D.DotProduct = function (v1, v2) {
        return v1.x * v2.x + v1.y * v2.y;
    };
    Vector2D.Equals = function (v1, v2) {
        return v1.x === v2.x && v1.y === v2.y;
    };
    Vector2D.Add = function (v1, v2) {
        return new Vector2D(v1.x + v2.x, v1.y + v2.y);
    };
    Vector2D.Subtract = function (v1, v2) {
        return new Vector2D(v1.x - v2.x, v1.y - v2.y);
    };
    Vector2D.Multiply = function (v, num) {
        return new Vector2D(v.x * num, v.y * num);
    };
    Vector2D.Divide = function (v, num) {
        return new Vector2D(v.x / num, v.y / num);
    };
    return Vector2D;
}());
exports.Vector2D = Vector2D;
