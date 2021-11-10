using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using SignalRWebPack.Hubs;
using SignalRWebPack.Network;
using SignalRWebPack;
using SignalRWebPack.Characters;
using SignalRWebPack.Managers;
using SignalRWebPack.Hubs.Worlds;
using SignalRWebPack.Facades;

namespace SignalRWebPack.Engine
{
    public class ServerEngine
    {
        private static ServerEngine instance;
        public static ServerEngine Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new ServerEngine();
                }
                return instance;
            }
            set { if(instance == null) instance = value; }
        }

        private static NetworkManager networkManager;
        public static NetworkManager NetworkManager 
        {
            get
            {
                if(networkManager == null)
                {
                    networkManager = new NetworkManager();
                }
                return networkManager;
            }
            set { if(networkManager == null) networkManager = value; }
        }

        public float UpdateTime { get; set; } = 0; // to do: optimize
        
        private readonly object ObjectProccessLock = new object();

        public List<IObject> waitingObjects = new List<IObject>();
        private Dictionary<string, IObject> instantiadedObjects = new Dictionary<string, IObject>();

        private long updateDelay = 300;
        private Stopwatch stopWatch;

        public void Initialize()
        {
            Task.Run(() => 
            {
                Console.WriteLine("SERVER ENGINE STARTING");
                UpdateTask();
            });

            Facade servas = new Facade();
            servas.Factory();
            servas.Builder();
        }

        public void SetNetworkManager(NetworkManager networkManager)
        {
            NetworkManager = networkManager;
        }
        public void SetInstance(ServerEngine serverEngine)
        {
            Instance = serverEngine;
        }

        //creates instance only on server
        public void CreateServerObject(IObject newObject)
        {
            lock (ObjectProccessLock)
            {
                waitingObjects.Add(newObject);
            }
        }

        //creates instance on server and client
        public void CreateNetworkObject(INetworkObject newObject)
        {
            lock (ObjectProccessLock)
            {
                newObject.NetworkManager = networkManager;

                waitingObjects.Add(newObject);
            }
        }

        public async void UpdateTask()
        {
            while (true)
            {
                stopWatch = Stopwatch.StartNew();

                lock (ObjectProccessLock)
                {
                    //start
                    if(waitingObjects.Count > 0)
                    {
                        List<IObject> newObjects = new List<IObject>(waitingObjects);
                        waitingObjects.Clear();
                        
                        foreach (IObject newObject in newObjects)
                        {
                            newObject.GUID = Guid.NewGuid().ToString();
                            newObject.Init();
                            instantiadedObjects.Add(newObject.GUID, newObject);

                            if(newObject is NetworkObject)
                            {
                                NetworkManager.AddNewObjectToGroup(newObject.AreaId, (NetworkObject)newObject);
                            }
                        }
                    }

                    //update
                    Dictionary<string, IObject> proccessedObjects = new Dictionary<string, IObject>();
                    foreach (string updatingObjectId in instantiadedObjects.Keys)
                    {
                        IObject updatingObject = instantiadedObjects[updatingObjectId];
                        if(updatingObject.IsDestroyed)
                        {
                            if(updatingObject is NetworkObject)
                            {
                                networkManager.RemoveNetworkObject((NetworkObject)updatingObject);
                            }

                            updatingObject.Destroy();
                        }
                        else
                        {
                            proccessedObjects.Add(updatingObjectId, updatingObject);
                            updatingObject.Update();
                        }
                    }
                    instantiadedObjects = proccessedObjects;
                }

                if(stopWatch.ElapsedMilliseconds < updateDelay)
                {
                    await Task.Delay((int)(updateDelay - stopWatch.ElapsedMilliseconds));
                }

                stopWatch.Stop();
                UpdateTime = (float)stopWatch.ElapsedMilliseconds / 1_000;
            }
        }

        public void InvokeObjectsMethod(string objectGuid, string method, object[] parameters)
        {
            if(!string.IsNullOrEmpty(method) && !string.IsNullOrEmpty(objectGuid) && instantiadedObjects.ContainsKey(objectGuid))
            {
                try
                {
                    IObject instantiadedObject = instantiadedObjects[objectGuid];
                    Type type = instantiadedObject.GetType();
                    MethodInfo methodInfo = type.GetMethod(method);
                    if(methodInfo == null) return;
                    methodInfo.Invoke(instantiadedObject, parameters);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public interface IObject
    {
        string GUID { get; set; }
        bool IsDestroyed { get; set; }
        Vector2D Position { get; set; }
        Collider Collider { get; set; }
        public string AreaId {get; set; }
        void Init();
        void Update();
        void Destroy();
    }

    public abstract class ServerObject : IObject
    {
        private Vector2D position;
        protected string guid = string.Empty;
        public string AreaId {get; set; }
        protected Collider collider;
        public virtual string GUID { get => guid; set => guid = value; }
        public Vector2D Position 
        {
            get { return position; }
            set
            {
                if(value != null)
                {
                    if(collider != null) collider.Boundry.Position = value;
                    position = value;
                }
            }
        }
        public Collider Collider { get => collider; set => collider = value; }

        public ServerObject()
        {
            ServerEngine.Instance.CreateServerObject(this);
        }
        public virtual bool IsDestroyed { get; set; }
        public virtual void Init(){}
        public virtual void Update(){}
        public virtual void Destroy(){}
    }

    public enum ServerObjectType
    {
        None,
        Character,
        NPC,
        EnemyNpc,
        FriendlyNpc,
        PassableObstacle,
        ImpassableObstacle,
        CommonWeapon,
        CommonArmor,
        CommonPotion,
        CommonFood,
        LegendaryWeapon,
        LegendaryArmor,
        LegendaryPotion,
        LegendaryFood
    }
}