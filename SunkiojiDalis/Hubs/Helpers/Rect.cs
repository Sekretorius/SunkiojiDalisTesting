using System;

public class Rect
{
    public Vector2D Position { get; set; }
    public Vector2D Size { get; set; }

    public Vector2D TopLeftCorner => new Vector2D(Position.X - Size.X / 2, Position.Y - Size.Y / 2);
    public Vector2D TopRightCorner => new Vector2D(Position.X + Size.X / 2, Position.Y - Size.Y / 2);
    public Vector2D BottomRightCorner => new Vector2D(Position.X + Size.X / 2, Position.Y + Size.Y / 2);
    public Vector2D BottomLeftCorner => new Vector2D(Position.X - Size.X / 2, Position.Y + Size.Y / 2);

    public Rect(Vector2D position, Vector2D size)
    {
        Position = position;
        Size = size;
    }

    public bool Contains(Vector2D point)
    {
        return point.X >= TopLeftCorner.X && point.X <= BottomRightCorner.X &&
            point.Y >= TopLeftCorner.Y && point.Y <= BottomRightCorner.Y;
    }

    public bool Intersects(Rect rectangle) 
    {
        return !(TopLeftCorner.X > rectangle.TopRightCorner.X ||
            TopRightCorner.X < rectangle.TopLeftCorner.X ||
            TopLeftCorner.Y > rectangle.BottomLeftCorner.Y ||
            BottomLeftCorner.Y < rectangle.TopLeftCorner.Y);
    }
}