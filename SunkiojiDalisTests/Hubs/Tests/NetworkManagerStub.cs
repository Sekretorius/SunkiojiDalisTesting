using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRWebPack.Hubs;
using SignalRWebPack.Network;

namespace SunkiojiDalisTests.Hubs.Tests
{
    public class NetworkManagerStub : NetworkManager
    {
        public override void AddNewObjectToAllClients(NetworkObject networkObject)
        {
            
        }
        public override void AddNewObjectToGroup(string groupId, NetworkObject networkObject)
        {
            
        }
        public override void AddNewObjectToSingleClient(string clientId, NetworkObject networkObject)
        {
            
        }
        public override List<NetworkRequest> FormGroupObjectCreateRequest(string groupId)
        {
            return null;   
        }
        public override Task SyncDataWithClient(string clientId, List<NetworkRequest> requests)
        {
            return new Task(() => { });
        }
        public override Task SyncDataWithClients(List<NetworkRequest> requests)
        {
            return new Task(() => { });
        }
        public override Task SyncDataWithGroup(string groupId, List<NetworkRequest> requests)
        {
            return new Task(() => { });
        }
        public override Task OnNewClientConnected(IClientProxy client)
        {
            return new Task(() => { });
        }

        public override Task OnAreaChange(Player player)
        {
            return new Task(() => { });
        }
    }
}
