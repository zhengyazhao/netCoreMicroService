using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using netCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
namespace IdentityServer4Test
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

            //services.AddIdentityServer();
            //var authenticationProviderKey = "TestKey";
            //Action<IdentityServerAuthenticationOptions> option = o =>
            //{
            //    o.ApiName = "api1";
            //    o.Authority = "http://127.0.0.1:3322";
            //    o.SupportedTokens = SupportedTokens.Both;
            //    o.ApiSecret = "laozheng";
            //    o.RequireHttpsMetadata = false;


            //};
            //services.AddAuthentication().AddIdentityServerAuthentication(authenticationProviderKey, option);

            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//添加认证
               .AddIdentityServerAuthentication("TestKey", o =>
               {
                   o.Authority = "http://127.0.0.1:3322";//要认证的服务器地址
                    o.RequireHttpsMetadata = false;//不启用https
                    o.ApiName = "api1";//要认证的服务名称
                                       //o.SupportedTokens = SupportedTokens.Both;
                                       //o.ApiSecret = "laozheng";
               });
     
            //services.AddAuthentication()
            //    .AddIdentityServerAuthentication("TestKey", o =>
            //    {
            //        o.ApiName = "api1";
            //        o.Authority = "http://127.0.0.1:3322";
            //        o.SupportedTokens = SupportedTokens.Both;
            //        o.ApiSecret = "laozheng";
            //        o.RequireHttpsMetadata = false;
            //    });

            services.AddOcelot(Configuration).AddConsul().AddPolly();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

       
            //app.RegisterConsul(Configuration);
            //app.UseHttpsRedirection();
            app.UseMvc();
     
            app.UseOcelot().Wait();
            app.UseAuthentication();
        }
    }
}
