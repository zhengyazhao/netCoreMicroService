using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WebApplication1.config;

namespace WebApplication1
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
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            #region redis注入
            //services.AddScoped<IRedisCacheManager, RedisCacheManager>();

            #endregion

            services.AddSwaggerGen(options=> {
                options.SwaggerDoc("v1", new Info() {
                    Title = "Swagger Test UI",
                    Version = "v1",
                    Description = "测试接口",
                    TermsOfService = "None",
                    
                    Contact = new Contact
                    {
                        Name = "测试测试",
                        Email = "zhengyazhao@chuangyutech.com",
                        Url = "www.chuangyu.com"
                    },
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "SwaggerDemo.xml");
                options.IncludeXmlComments(xmlPath);
            });
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

            app.UseHttpsRedirection();

            app.UseSwagger();
            // 在这里面可以注入
            app.UseSwaggerUI(options =>
            {
                //options.InjectOnCompleteJavaScript("/swagger/ui/zh_CN.js"); // 加载中文包
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "HKERP API V1");
            });
            app.UseMvc();
        }
    }
}
