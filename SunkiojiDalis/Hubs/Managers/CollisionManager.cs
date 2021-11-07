using SignalRWebPack.Engine;
using System.Collections.Generic;
using System.Threading.Tasks;
public class CollisionManager
{
    private readonly object CollisionProccessLock = new object();
    private const int TreeMaxCapacity = 4;
    private Dictionary<string, QuadTree> colliderTrees = new Dictionary<string, QuadTree>();
    private Dictionary<string, List<Collider>> colliders = new Dictionary<string, List<Collider>>();
    private Dictionary<Collider, Dictionary<Collider, List<ColliderPoint>>> collisions = new Dictionary<Collider, Dictionary<Collider, List<ColliderPoint>>>();
    public void Init() // here initialize collision maps for different world areas
    {
        Vector2D mapSize = new Vector2D(800, 500);
        Vector2D mapCenter = new Vector2D(mapSize.X / 2, mapSize.Y / 2);

        colliderTrees.Add("0", new QuadTree(new Rect(mapCenter, mapSize), TreeMaxCapacity));
    }
    public void Update()
    {
        collisions.Clear();
        BuildCollisionMap();

        ProccessMapCollisions();
        InvokeCollisions();
    }
    public void RegisterCollider(string id, Collider collider)
    {
        if(!colliders.ContainsKey(id))
        {
            colliders.Add(id, new List<Collider>());
        }
        colliders[id].Add(collider);
    }
    public void UnRegisterCollider(Collider collider)
    {
        foreach(List<Collider> colliders in colliders.Values)
        {
            colliders.Remove(collider); // it should contain map id - that would make it faster then iterate thru values
        }
    }
    private void BuildCollisionMap()
    {
        List<Task> buildTasks = new List<Task>();
        List<string> keys = new List<string>(colliderTrees.Keys);

        foreach(string key in keys)
        {
            Rect boundry = colliderTrees[key].Boundry;
            colliderTrees[key] = new QuadTree(boundry, TreeMaxCapacity);

            if(colliders.ContainsKey(key))
            {
                buildTasks.Add(Task.Run(() => { BuildColisionTree(colliderTrees[key], colliders[key]); }));
            }
        }

        Task waitTask = Task.WhenAll(buildTasks);
        waitTask.Wait();
    }
    private void BuildColisionTree(QuadTree quadTree, List<Collider> colliders)
    {
        foreach(Collider collider in colliders)
        {
            quadTree.Insert(collider);
        }
    }
    private void ProccessMapCollisions()
    {
        List<Task> checkTasks = new List<Task>();
        foreach(string key in colliderTrees.Keys)
        {
            if(colliders.ContainsKey(key))
            {
                checkTasks.Add(Task.Run(() => { CheckColisions(colliderTrees[key], colliders[key]); }));
            }
        }

        Task waitTask = Task.WhenAll(checkTasks);
        waitTask.Wait();
    }
    private void CheckColisions(QuadTree quadTree, List<Collider> colliders)
    {
        foreach(Collider collider in colliders)
        {
            FillCollisionMap(collider, quadTree.Query(collider.Boundry));
        }
    }
    private void FillCollisionMap(Collider collider, List<ColliderPoint> collisionPoints)
    {
        if(collisionPoints.Count == 0) return;

        lock(CollisionProccessLock)
        {
            if(collider.GameObject != null && !collisions.ContainsKey(collider))
            {
                collisions.Add(collider, new Dictionary<Collider, List<ColliderPoint>>());
            }

            foreach(ColliderPoint point in collisionPoints)
            {
                if(point.Collider != collider)
                {
                    if(collider.GameObject != null)
                    {
                        if(!collisions[collider].ContainsKey(point.Collider))
                        {
                            collisions[collider].Add(point.Collider, new List<ColliderPoint>());
                        }

                        collisions[collider][point.Collider].Add(point);
                    }
                    AddCollisionToMap(point.Collider, collider, new ColliderPoint(collider, point.ColliderVertex));
                }
            }
        }
    }
    private void AddCollisionToMap(Collider collider, Collider collisionCollider, ColliderPoint colliderPoint)
    {
        if(!collisions.ContainsKey(collider))
        {
            collisions.Add(collider, new Dictionary<Collider, List<ColliderPoint>>());
        }

        if(!collisions[collider].ContainsKey(collisionCollider))
        {
            collisions[collider].Add(collisionCollider, new List<ColliderPoint>());
        }
    }
    private void InvokeCollisions()
    {
        foreach(Collider collider in collisions.Keys)
        {
            foreach(Collider collisionCollider in collisions[collider].Keys)
            {
                collider.OnCollision(new Collision(collisionCollider, collisions[collider][collisionCollider]));
            }
        }
    }
}

public class Collision
{
    public Collider Collider { get; private set; }
    public List<ColliderPoint> ColliderPoints { get; private set; } = new List<ColliderPoint>();

    public Collision(Collider collider, List<ColliderPoint> colliderPoints)
    {
        Collider = collider;
        ColliderPoints = colliderPoints;
    }
}