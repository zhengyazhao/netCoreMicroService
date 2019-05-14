using Consul;
using ConsulRegins;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.Configuration;
using Model.consulRegin;
using System;
using System.Collections.Generic;
using System.Linq;
namespace netCore
{
    public static class ApplicationBuilderExtensions
    {

        /// <summary>
        /// 注册consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        /// <param name="serviceEntity"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            ConsulServiceOption consulServiceOption = new ConsulServiceOption();
            configuration.GetSection("ServiceDiscovery").Bind(consulServiceOption);
            consulRegistyHost consulRegistyHost = new consulRegistyHost(consulServiceOption.Consul);

            Uri address = new Uri("http://localhost:8100");
            Uri healthCheck = new Uri(address, consulServiceOption.HealthCheckTemplate);
          var  test= consulRegistyHost.serviceRegister(address, consulServiceOption.ServiceName, consulServiceOption.Version, healthCheck, tags: new[] { $"test-/{consulServiceOption.ServiceName}" }).Result;

            return app;
        }

        ////public static IApplicationBuilder useConsulRegisterService(this IApplicationBuilder app, ConsulServiceOption consulServiceOption)
        ////{

        ////}
    }


}
