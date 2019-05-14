using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IndentityServerClientTest
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

            services.AddAuthentication("TestKey")
            
               .AddIdentityServerAuthentication("TestKey",options =>
               {
                   options.Authority = "http://localhost:3322";//IdentityServer服务地址
                   options.ApiName = "api1"; //服务的名称
                   options.RequireHttpsMetadata = false;
               });

          //  services.AddAuthentication()
          //.AddIdentityServerAuthentication("ChatKey", o => {
          //     //IdentityService认证服务的地址
          //     o.Authority = "http://localhost:9500";
          //    o.ApiName = "chatapi";//要连接的应用的名字
          //     o.RequireHttpsMetadata = false;
          //    o.SupportedTokens = SupportedTokens.Both;
          //    o.ApiSecret = "123321";//秘钥
          // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
