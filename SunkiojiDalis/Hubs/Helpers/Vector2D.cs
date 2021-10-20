using System;
public class Vector2D
{
    public float X { get; set; } = 0;
    public float Y { get; set; } = 0;
    public Vector2D(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }

    public float GetMagnidute() 
    {
        return (float)Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
    }

    public Vector2D Normalize() 
    {
        float magnitude = this.GetMagnidute();
        return this / magnitude;
    }

    public Vector2D DirectionTo(Vector2D to) 
    {
        return to - this;
    }
    
    public static Vector2D Lerp(Vector2D origin, Vector2D target, float t)
    {
        Vector2D direction = origin.DirectionTo(target);
        return origin + direction * t;
    }

    public static Vector2D ProjectOn(Vector2D vector, Vector2D prjectionVector) 
    {
        Vector2D normalizedV = prjectionVector.Normalize();
        float dotProduct = Vector2D.DotProduct(vector, normalizedV);
        return normalizedV * dotProduct;
    }

    public static float DotProduct(Vector2D v1, Vector2D v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
#region Operators
    public static bool operator == (Vector2D v1, Vector2D v2)
    {
        if(v1 is null && v2 is null) return true;
        if(v1 is null) return false;
        if(v2 is null) return false;

        return v1.X == v2.X && v1.Y == v2.Y;
    }

    public static bool operator != (Vector2D v1, Vector2D v2)
    {
        if(v1 is null && v2 is null) return false;
        if(v1 is null) return true;
        if(v2 is null) return true;

        return v1.X != v2.X || v1.Y != v2.Y;
    }

    public static Vector2D operator + (Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
    }

    public static Vector2D operator - (Vector2D v1, Vector2D v2)
    {
        return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
    }

    public static Vector2D operator * (Vector2D v, float num)
    {
        return new Vector2D(v.X * num, v.Y * num);
    }
    public static Vector2D operator * (float num, Vector2D v)
    {
        return new Vector2D(v.X * num, v.Y * num);
    }

    public static Vector2D operator / (Vector2D v, float num)
    {
        return new Vector2D(v.X / num, v.Y / num);
    }

    public static Vector2D operator / (float num, Vector2D v)
    {
        return new Vector2D(v.X / num, v.Y / num);
    }
#endregion
}