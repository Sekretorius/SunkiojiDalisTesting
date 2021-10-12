using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SunkiojiDalis.Hubs;
using Microsoft.AspNetCore.SignalR;
using SunkiojiDalis.Engine;

namespace SunkiojiDalis
{
    public class Program
    {
        public static IHubContext<ChatHub> IHubContext;
        
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            IHubContext = (IHubContext<ChatHub>)host.Services.GetService(typeof(IHubContext<ChatHub>));
            ServerEngine.Instance.Initialize();
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
