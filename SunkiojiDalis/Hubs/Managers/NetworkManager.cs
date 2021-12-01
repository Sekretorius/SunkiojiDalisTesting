using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebPack.Engine;
using SignalRWebPack.Hubs;


namespace SignalRWebPack.Network
{
	public class NetworkManager : ServerObject
	{
        private readonly object ServerRequestProccessLock = new object();
        private readonly object ClientRequestProccessLock = new object();
        private readonly object ProccessNetworkObjectLock = new object();
        
        private const string ClientRequestHandlerMethod = "ClientRequestHandler";

        private IHubContext<ChatHub> GameHub;

        private List<NetworkObject> networkObjects = new List<NetworkObject>();

        private List<NetworkRequest> allClientsRequestQueue = new List<NetworkRequest>();
        private Dictionary<string, List<NetworkRequest>> clientGroupRequestQueue = new Dictionary<string, List<NetworkRequest>>();
        private Dictionary<string, List<NetworkRequest>> singleClientRequestQueue = new Dictionary<string, List<NetworkRequest>>();

        private List<NetworkRequest> clientsRequestQueue = new List<NetworkRequest>();

        private int totalGroupRequestCount = 0;
        private int totalsingleClientRequestCount = 0;
        private int totalallClientsRequestCount = 0;

        public NetworkManager() : base()
        {

        }
        
        public override bool IsDestroyed { get; set; }
        
        public void SetHubContext(IHubContext<ChatHub> Hub)
        {
            GameHub = Hub;
        }

        public override void Init() 
        { 
            Console.WriteLine("NETWORK MANAGER STARTING");
        }

        public override void Update() 
        {
            //proccess server requests
            if(allClientsRequestQueue.Count > 0 || clientGroupRequestQueue.Values.Count > 0 || singleClientRequestQueue.Values.Count > 0)
            {
                lock(ServerRequestProccessLock)
                {
                    List<Task> messageTasks = new List<Task>();
                    
                    //proccess all client requests
                    messageTasks.Add(Task.Run(async () => { await SyncDataWithClients(allClientsRequestQueue); }));
                    
                    //proccess client group requests
                    messageTasks.Add(Task.Run(async () => 
                    {
                        foreach(string groupId in clientGroupRequestQueue.Keys)
                        {
                            await SyncDataWithGroup(groupId, clientGroupRequestQueue[groupId]);
                        }
                    }));

                    //proccess single client requests
                    messageTasks.Add(Task.Run(async () => 
                    {
                        foreach(string clientId in singleClientRequestQueue.Keys)
                        {
                            await SyncDataWithClient(clientId, singleClientRequestQueue[clientId]);
                        }
                    }));

                    Task sendMessagesTask = Task.WhenAll(messageTasks);
                    sendMessagesTask.Wait(); 
                    
                    allClientsRequestQueue.Clear();
                    clientGroupRequestQueue.Clear();
                    singleClientRequestQueue.Clear();
                }
            }

            GetTotalRequestDataCount();

            //proccess client requests
            if (clientsRequestQueue.Count != 0)
            {
                lock(ClientRequestProccessLock)
                {
                    foreach(NetworkRequest clientsRequest in clientsRequestQueue)
                    {
                        ServerEngine.Instance.InvokeObjectsMethod(clientsRequest.RequestObjectGuid, clientsRequest.RequestMethod, new object[] { clientsRequest.RequestData });
                    }
                    clientsRequestQueue.Clear();
                }
            }
        }

        public void RemoveNetworkObject(NetworkObject networkObject)
        {
            networkObjects.Remove(networkObject);
        }

        public virtual void AddNewObjectToAllClients(NetworkObject networkObject){
            if(networkObject == null) return;
            
            lock(ProccessNetworkObjectLock)
            {
                networkObjects.Add(networkObject); //to do: separete this;
                if(!networkObject.CreateOnClient) return;

                AddRequestToAllClients(new NetworkRequest(
                    networkObject.GUID,
                    nameof(MainNetworkRequests.CreateClientObject),
                    JsonConvert.SerializeObject(networkObject.OnClientSideCreation())
                ));
            }
        }

        public virtual void AddNewObjectToGroup(string groupId, NetworkObject networkObject){
            if(networkObject == null) return;
            
            lock(ProccessNetworkObjectLock)
            {
                networkObjects.Add(networkObject); //to do: separete this;
                if(!networkObject.CreateOnClient || string.IsNullOrEmpty(groupId)) return;

                AddRequestToGroup(groupId, new NetworkRequest(
                    networkObject.GUID,
                    nameof(MainNetworkRequests.CreateClientObject),
                    JsonConvert.SerializeObject(networkObject.OnClientSideCreation())
                ));
            }
        }

        public virtual void AddNewObjectToSingleClient(string clientId, NetworkObject networkObject){
            if(networkObject == null) return;

            lock(ProccessNetworkObjectLock)
            {
                networkObjects.Add(networkObject); //to do: separete this;
                if(!networkObject.CreateOnClient || string.IsNullOrEmpty(clientId)) return;

                AddRequestToGroup(clientId, new NetworkRequest(
                    networkObject.GUID,
                    nameof(MainNetworkRequests.CreateClientObject),
                    JsonConvert.SerializeObject(networkObject.OnClientSideCreation())
                ));
            }
        }

        public void AddRequestToAllClients(NetworkRequest request)
        {
            if(request == null) return;
            lock(ServerRequestProccessLock)
            {
                allClientsRequestQueue.Add(request);
            }
        }

        public void AddRequestToGroup(string groupId, NetworkRequest request)
        {
            if(request == null || string.IsNullOrEmpty(groupId)) return;
            lock(ServerRequestProccessLock)
            {
                if(!clientGroupRequestQueue.ContainsKey(groupId))
                {
                    clientGroupRequestQueue.Add(groupId, new List<NetworkRequest>());
                }
                clientGroupRequestQueue[groupId].Add(request);
            }
        }

        public void AddRequestToSingleClient(string clientId, NetworkRequest request)
        {
            if(request == null || string.IsNullOrEmpty(clientId)) return;
            lock(ServerRequestProccessLock)
            {
                if(!singleClientRequestQueue.ContainsKey(clientId))
                {
                    singleClientRequestQueue.Add(clientId, new List<NetworkRequest>());
                }
                singleClientRequestQueue[clientId].Add(request);
            }
        }

        public virtual async Task SyncDataWithClients(List<NetworkRequest> requests)
        {
            if (GameHub == null || requests == null || requests.Count == 0) return;
            string requestData = JsonConvert.SerializeObject(requests);
            await GameHub.Clients.All.SendAsync(ClientRequestHandlerMethod, requestData);
        }

        public virtual async Task SyncDataWithGroup(string groupId, List<NetworkRequest> requests)
        {
            if (GameHub == null || requests == null || requests.Count == 0) return;
            string requestData = JsonConvert.SerializeObject(requests);
            await GameHub.Clients.Group(groupId).SendAsync(ClientRequestHandlerMethod, requestData);
        }

        public virtual async Task SyncDataWithClient(string clientId, List<NetworkRequest> requests)
        {
            if (GameHub == null || requests == null || requests.Count == 0) return;
            string requestData = JsonConvert.SerializeObject(requests);
            await GameHub.Clients.Client(clientId).SendAsync(ClientRequestHandlerMethod, requestData);
        }

        public virtual void GetGroupRequestDataCount()
        {
            foreach(string guid in clientGroupRequestQueue.Keys)
            {
                totalGroupRequestCount += clientGroupRequestQueue[guid].Count;
            }
        }
        public virtual void GetSingleClientRequestDataCount()
        {
            foreach (string guid in singleClientRequestQueue.Keys)
            {
                totalsingleClientRequestCount += clientGroupRequestQueue[guid].Count;
            }
        }
        public virtual void GetTotalRequestDataCount()
        {
            GetGroupRequestDataCount();
            GetSingleClientRequestDataCount();
            totalallClientsRequestCount = totalGroupRequestCount + totalsingleClientRequestCount;
        }


        public void HandleClientRequest(string incommingData)
        {
            if(string.IsNullOrEmpty(incommingData)) return;
            try
            {
                lock(ClientRequestProccessLock)
                {
                    List<NetworkRequest> clientsRequests = JsonConvert.DeserializeObject<List<NetworkRequest>>(incommingData);
                    clientsRequestQueue.AddRange(clientsRequests);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<NetworkRequest> FormAllObjectCreateRequest() //to do: make forms for group areas 
        {
            lock(ProccessNetworkObjectLock)
            {
                List<NetworkRequest> createRequests = new List<NetworkRequest>();
                foreach (NetworkObject networkObject in networkObjects)
                {
                    if(!networkObject.CreateOnClient) continue;
                    createRequests.Add(new NetworkRequest(
                        networkObject.GUID,
                        nameof(MainNetworkRequests.CreateClientObject),
                        JsonConvert.SerializeObject(networkObject.OnClientSideCreation())
                    ));
                }
                return createRequests;
            }
        }

        public virtual List<NetworkRequest> FormGroupObjectCreateRequest(string groupId) //to do: make forms for group areas 
        {
            lock(ProccessNetworkObjectLock)
            {
                List<NetworkRequest> createRequests = new List<NetworkRequest>();
                foreach (NetworkObject networkObject in networkObjects)
                {
                    if(!networkObject.CreateOnClient || networkObject.AreaId != groupId) continue;
                    createRequests.Add(new NetworkRequest(
                        networkObject.GUID,
                        nameof(MainNetworkRequests.CreateClientObject),
                        JsonConvert.SerializeObject(networkObject.OnClientSideCreation())
                    ));
                }
                return createRequests;
            }
        }

        public virtual async Task OnNewClientConnected(IClientProxy client) //to do: has to have different functionality // if it spawns in area ...
        {
            List<NetworkRequest> requestForms = FormGroupObjectCreateRequest("3,3");
            if(requestForms.Count > 0)
            {
                string requestData = JsonConvert.SerializeObject(requestForms);
                await client.SendAsync(ClientRequestHandlerMethod, requestData);
            }
        }

        public virtual async Task OnAreaChange(Player player) //to do: has to have different functionality // if it spawns in area ...
        {
            var requestData = JsonConvert.SerializeObject(new List<NetworkRequest>() { new NetworkRequest("", nameof(MainNetworkRequests.RemoveAllObjects), "")});
            await player.proxy.SendAsync(ClientRequestHandlerMethod, requestData);
            List<NetworkRequest> requestForms = FormGroupObjectCreateRequest(player.GetGroupId());
            if(requestForms.Count > 0)
            {
                string serializedData = JsonConvert.SerializeObject(requestForms);
                await player.proxy.SendAsync(ClientRequestHandlerMethod, serializedData);
            }
        }
        public override void Destroy() 
        { 
        
        }
    }

#region NetworkObjects

	public interface INetworkObject : IObject
	{
        NetworkManager NetworkManager { get; set; }
        bool CreateOnClient { get; set; }
        Dictionary<string, string> OnClientSideCreation();
	}


    public class NetworkObject : INetworkObject
    {
        [JsonIgnore] private Vector2D position;
        [JsonIgnore] public string AreaId {get; set;}
        [JsonIgnore] protected string guid = string.Empty;
        [JsonIgnore] protected bool createOnClient = true;
        [JsonIgnore] protected Collider collider;

        [JsonIgnore] public NetworkManager NetworkManager { get; set; }
        [JsonIgnore] public virtual bool CreateOnClient { get => createOnClient; set => createOnClient = value; }
        [JsonIgnore] public virtual string GUID { get => guid; set => guid = value; }
        [JsonIgnore] public Vector2D Position 
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

        [JsonIgnore] public Collider Collider { get => collider; set => collider = value; }
        [JsonIgnore] public virtual bool IsDestroyed { get; set; }
        
        public NetworkObject()
        {
            ServerEngine.Instance.CreateNetworkObject(this);
        }

        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Destroy() 
        { 
            SyncDataWithGroup(AreaId, "Destroy", null);
        }
        public virtual void SyncDataWithClients(string method, string dataJson)
        {
            NetworkManager.AddRequestToAllClients(new NetworkRequest(guid, method, dataJson));
        }

        public virtual bool SyncDataWithGroup(string groupId, string method, string dataJson)
        {
            NetworkManager.AddRequestToGroup(groupId, new NetworkRequest(guid, method, dataJson));
            return true;
        }

        public virtual void SyncDataWithClient(string clientId, string method, string dataJson)
        {
            NetworkManager.AddRequestToSingleClient(clientId, new NetworkRequest(guid, method, dataJson));
        }

        public virtual Dictionary<string, string> OnClientSideCreation()
        {
            return new Dictionary<string, string>();
        }
    }

#endregion
#region NetworkRequests

    public class NetworkRequest
    {
        public string RequestObjectGuid { get; set; }
        public string RequestMethod { get; set; }
        public string RequestData { get; set; }

        public NetworkRequest(string requestObjectGuid, string requestMethod, string dataJson)
        {
            RequestObjectGuid = requestObjectGuid;
            RequestMethod = requestMethod;
            RequestData = dataJson;
        }
    }

#endregion

#region MainRequests
    public enum MainNetworkRequests
    {
        CreateClientObject,
        RemoveAllObjects
    }
#endregion
}
