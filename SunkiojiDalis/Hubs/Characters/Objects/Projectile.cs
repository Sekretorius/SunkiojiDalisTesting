using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Engine;
using SignalRWebPack.Network;

public class Projectile : NetworkObject
{
    private Vector2D direction;
    private float speed;
    private string sprite;

    private int width;
    private int height;

    private float lifeSpan = 5f;
    private float timmer = 0;

    public Projectile(string areaId, string sprite, Vector2D position, Rect boundry, float speed, Vector2D direction, float lifeSpan = 5) : base()
    {
        this.AreaId = areaId;
        
        this.Position = position;
        this.sprite = sprite;

        this.collider = new Collider(boundry, this);
        this.direction = direction;

        this.width = (int)boundry.Size.X;
        this.height = (int)boundry.Size.Y;

        this.speed = speed;
        this.direction = direction;

        this.lifeSpan = lifeSpan;
    }
    public override void Update()
    {
        timmer += ServerEngine.Instance.UpdateTime;
        if (timmer >= lifeSpan)
        {
            IsDestroyed = true;
            Destroy();
            return;
        }

        Position += direction * speed * ServerEngine.Instance.UpdateTime;
        SyncDataWithGroup(AreaId, "SyncPosition", $"{{\"x\":\"{this.Position.X}\", \"y\":\"{this.Position.Y}\"}}");
    }

    public override Dictionary<string, string> OnClientSideCreation()
    {
        Dictionary<string, string> projectileData = new Dictionary<string, string>()
        {
            { "objectType", "Projectile" },
            { "sprite", sprite },
            { "x", Position.X.ToString() },
            { "y", Position.Y.ToString() },
            { "speed", speed.ToString() },
            { "width", width.ToString() },
            { "height", height.ToString() },
        };
        return projectileData;
    }
}