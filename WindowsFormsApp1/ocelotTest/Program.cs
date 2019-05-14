using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ocelotTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>()
            .UseUrls("http://localhost:8683")
         .ConfigureAppConfiguration(conf => {
             conf.AddJsonFile("OcelotSettings.json", optional: false, reloadOnChange: true);
         })
             .Build();
    }
}
