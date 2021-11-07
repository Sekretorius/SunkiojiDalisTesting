using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Linq;
using SignalRWebPack.Characters;
using SignalRWebPack.Obstacles;

namespace SignalRWebPack.Managers
{
    public class ObstacleCreator : Creator<Obstacle, ObstacleType>
    {
        public Obstacle FactoryMethod(ObstacleType obstacleType, string subtype, string area)
        {
            var rng = new Random();
            switch (obstacleType)
            {
                case ObstacleType.Passable:
                    if(subtype == "bush"){
                        return new PassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/obstacles/passable/bush.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Type: "Harmless");
                    }
                    if(subtype == "cactus"){
                        return new PassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/obstacles/passable/cactus.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Type: "Harmful");
                    }
                    return new PassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/characters/bush.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Type: "Harmless");
                case ObstacleType.Impassable:
                    if(subtype == "house1"){
                        return new ImpassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/obstacles/impassable/house1.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Effect: "None");
                    }
                    if(subtype == "house2"){
                        return new ImpassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/obstacles/impassable/house2.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Effect: "None");
                    }
                    if(subtype == "rocks1"){
                        return new ImpassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/obstacles/impassable/rocks1.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Effect: "None");
                    }
                    if(subtype == "tree1"){
                        return new ImpassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/obstacles/impassable/tree1.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Effect: "None");
                    }
                    return new ImpassableObstacle(AreaId: area, Id: rng.Next(1, 9999999), Sprite: "resources/obstacles/impassable/rocks1.png", X: rng.Next(20, 780), Y: rng.Next(20, 480), Effect: "None");
                default:
                    return null;
            }
        }
    }
}