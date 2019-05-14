using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IdentityServer4Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
     
            CreateWebHostBuilder(args).Build().Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)

        //        .UseStartup<Startup>();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseUrls($"http://{ config["ip"]}:{ config["port"]}")//配置ip地址和端口地址
                .UseStartup<Startup>();


            return webHostBuilder;



        }
    }
}
