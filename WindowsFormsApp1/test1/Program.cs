using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace test1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args)
             .Build();//获取配置信息
            string ip = "localhost";
            string port = "6644";
            if (!string.IsNullOrWhiteSpace(config["ip"]) && !string.IsNullOrWhiteSpace(config["port"]))
            {
                ip = config["ip"];
                port = config["port"];
            }
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls($"http://{ip}:{port}")//配置ip地址和端口地址
                .UseStartup<Startup>();
        }
    }
}
