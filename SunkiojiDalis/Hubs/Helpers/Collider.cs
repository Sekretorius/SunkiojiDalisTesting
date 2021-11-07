using SignalRWebPack.Engine;
public class Collider
{
    public Rect Boundry { get; set; }
    public IObject GameObject { get; private set; }

    public Collider(Rect boundry) // will not receive collision invokes
    {
        Boundry = boundry;
    }
    public Collider(Rect boundry, IObject gameObject)
    {
        Boundry = boundry;
        GameObject = gameObject;
    }
    public virtual void OnCollision(Collision collision)
    {
        if(GameObject != null)
        {
            GameObject.OnCollision(collision);
        }
    }
}