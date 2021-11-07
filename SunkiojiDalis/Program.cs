using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SignalRWebPack.Hubs;
using Microsoft.AspNetCore.SignalR;
using SignalRWebPack.Engine;
using SignalRWebPack.Network;

namespace SignalRWebPack
{
    public class Program
    {
		public static IHubContext<ChatHub> IHubContext;
		
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            IHubContext = (IHubContext<ChatHub>)host.Services.GetService(typeof(IHubContext<ChatHub>));
            ServerEngine.Instance.Initialize();
             TestingManager mang = new TestingManager();
            mang.Testing();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
