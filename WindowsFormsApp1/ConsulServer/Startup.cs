using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using ConsulServer.ConsulApi;
using ConsulServer.entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsulServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {

        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ////配置信息单例
            //ConfigSingleton.setConfigSingleton(Configuration);
           
            app.UseMvc();
            app.UseAuthentication();
            ConsulEntity consulEntity = new ConsulEntity
            {
                ip = Configuration["ip"],
                port = int.Parse(Configuration["port"] ),
                ServiceName = "zyz1",
                ConsulIP = Configuration["Consul:IP"],
                ConsulPort = Convert.ToInt32(Configuration["Consul:Port"])
            };
               app.RegisterConsul(lifetime, consulEntity);
        }

    }
}
