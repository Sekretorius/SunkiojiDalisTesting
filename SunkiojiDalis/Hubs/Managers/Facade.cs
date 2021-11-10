using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SignalRWebPack.Characters;
using SignalRWebPack.Managers;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Hubs;
using SignalRWebPack.Network;
using System.Diagnostics;

namespace SignalRWebPack.Facades
{
    public class Facade
    {
        public Facade(){
            Console.WriteLine("Facade started");
        }
        protected NPC test1;
        protected NPC test2;

        public void Builder(){
            var director = new Director();
            var builder = new DesertBuilder(2, 3);
            director.Builder = builder;
            director.BuildArea();
            var desert = builder.GetProduct();
            World.Instance.SwapArea(desert);

            var forestBuilder = new ForestBuilder(4, 3);
            director.Builder = forestBuilder;
            director.BuildArea();
            var forest = forestBuilder.GetProduct();
            World.Instance.SwapArea(forest);
        }
        public void Factory(){
            NpcCreator npcCreator = new NpcCreator();
            NPC friendly = npcCreator.FactoryMethod(NpcType.Friendly, "", $"{3},{3}");
            NPC enemy = npcCreator.FactoryMethod(NpcType.Enemy, "", $"{2},{3}");
            friendly.SetMoveAlgorithm(new Stand());
            enemy.SetMoveAlgorithm(new Walk());
            friendly.SetAttackAlgorithm(new Melee(friendly.AreaId, 0, 0));
            enemy.SetAttackAlgorithm(new Melee(enemy.AreaId, 10, 50));
            World.Instance.AddNPC(friendly);
            World.Instance.AddNPC(enemy);
        }
    }
}