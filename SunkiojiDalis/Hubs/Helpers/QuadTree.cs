using System;
using System.Collections.Generic;

public class QuadTree
{
    public Rect Boundry;
    private int maxCapacity = 0;
    private bool isDivided = false;
    private QuadTree TopLeft;
    private QuadTree TopRight;
    private QuadTree BottomLeft;
    private QuadTree BottomRight;
    private List<ColliderPoint> points = new List<ColliderPoint>();

    public QuadTree(Rect boundry, int maxCapacity)
    {
        this.Boundry = boundry;
        this.maxCapacity = maxCapacity;
    }

    public void Insert(Collider collider)
    {
        Insert(new ColliderPoint(collider, collider.Boundry.BottomLeftCorner));
        Insert(new ColliderPoint(collider, collider.Boundry.BottomRightCorner));
        Insert(new ColliderPoint(collider, collider.Boundry.TopLeftCorner));
        Insert(new ColliderPoint(collider, collider.Boundry.TopRightCorner));
    }
    public bool Insert(ColliderPoint colliderPoint)
    {
        if (!Boundry.Contains(colliderPoint.ColliderVertex)) return false;
        if (points.Count < maxCapacity)
        {
            points.Add(colliderPoint);
            return true;
        }
        else
        {
            if (!isDivided)
            {
                TopLeft = new QuadTree(new Rect(new Vector2D(Boundry.Position.X - Boundry.Size.X / 4, Boundry.Position.Y - Boundry.Size.Y / 4), new Vector2D(Boundry.Size.X / 2, Boundry.Size.Y / 2)), maxCapacity);
                TopRight = new QuadTree(new Rect(new Vector2D(Boundry.Position.X + Boundry.Size.X / 4, Boundry.Position.Y - Boundry.Size.Y / 4), new Vector2D(Boundry.Size.X / 2, Boundry.Size.Y / 2)), maxCapacity);
                BottomLeft = new QuadTree(new Rect(new Vector2D(Boundry.Position.X - Boundry.Size.X / 4, Boundry.Position.Y + Boundry.Size.Y / 4), new Vector2D(Boundry.Size.X / 2, Boundry.Size.Y / 2)), maxCapacity);
                BottomRight = new QuadTree(new Rect(new Vector2D(Boundry.Position.X + Boundry.Size.X / 4, Boundry.Position.Y + Boundry.Size.Y / 4), new Vector2D(Boundry.Size.X / 2, Boundry.Size.Y / 2)), maxCapacity);
                isDivided = true;
            }

            if(TopLeft.Insert(colliderPoint)) return true;
            if(TopRight.Insert(colliderPoint)) return true;
            if(BottomLeft.Insert(colliderPoint)) return true;
            if(BottomRight.Insert(colliderPoint)) return true;
        }

        return false;
    }

    public List<ColliderPoint> Query(Rect rectangle)
    {
        if (!Boundry.Intersects(rectangle)) return new List<ColliderPoint>();

        List<ColliderPoint> foundPoints = new List<ColliderPoint>();
        foreach (ColliderPoint point in points)
        {
            if (rectangle.Contains(point.ColliderVertex))
            {
                foundPoints.Add(point);
            }
        }

        if (isDivided)
        {
            foundPoints.AddRange(TopLeft.Query(rectangle));
            foundPoints.AddRange(TopRight.Query(rectangle));
            foundPoints.AddRange(BottomLeft.Query(rectangle));
            foundPoints.AddRange(BottomRight.Query(rectangle));
        }

        return foundPoints;
    }
}


public class ColliderPoint
{
    public Collider Collider { get; set; }
    public Vector2D ColliderVertex { get; set; }

    public ColliderPoint(Collider collider, Vector2D colliderVertex)
    {
        Collider = collider;
        ColliderVertex = colliderVertex;
    }
}