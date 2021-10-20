export class Vector2D{
    x: number;
    y: number;

    constructor(x: number, y: number){
        this.x = x;
        this.y = y;
    }

    GetMagnidute(): number {
        return Math.sqrt(this.x ** 2 + this.y ** 2);
    }

    Normalize(): Vector2D {
        let magnitude = this.GetMagnidute();
        return new Vector2D(this.x / magnitude, this.y / magnitude);
    }

    DirectionTo(to: Vector2D): Vector2D {
        return Vector2D.Subtract(to, this);
    }
    
    static Lerp(origin: Vector2D, target: Vector2D, t: number): Vector2D {
        let direction = origin.DirectionTo(target);
        return new Vector2D(origin.x + direction.x * t, origin.y + direction.y * t);
    }

    static ProjectOn(vector: Vector2D, prjectionVector: Vector2D): Vector2D {
        let normaizedV = prjectionVector.Normalize();
        let dotProduct = Vector2D.DotProduct(vector, normaizedV);
        return Vector2D.Multiply(normaizedV, dotProduct);
    }

    static DotProduct(v1: Vector2D, v2: Vector2D): number {
        return v1.x * v2.x + v1.y * v2.y;
    }

    static Equals(v1: Vector2D, v2: Vector2D): boolean {
        return v1.x === v2.x && v1.y === v2.y;
    }

    static Add(v1: Vector2D, v2: Vector2D): Vector2D{
        return new Vector2D(v1.x + v2.x, v1.y + v2.y);
    }

    static Subtract(v1: Vector2D, v2: Vector2D){
        return new Vector2D(v1.x - v2.x, v1.y - v2.y);
    }

    static Multiply(v: Vector2D, num: number){
        return new Vector2D(v.x * num, v.y * num);
    }
    
    static Divide(v: Vector2D, num: number){
        return new Vector2D(v.x / num, v.y / num);
    }
}