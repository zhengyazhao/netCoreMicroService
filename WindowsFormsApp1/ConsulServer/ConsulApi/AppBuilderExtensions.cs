﻿
using Consul;
using ConsulServer.entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsulServer.ConsulApi
{
    /// <summary>
    /// consul学习
    /// </summary>
    public static class AppBuilderExtensions
    {

        /// <summary>
        /// 注册consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        /// <param name="serviceEntity"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IApplicationLifetime lifetime, ConsulEntity serviceEntity)
        {
            //consul地址
            Action<ConsulClientConfiguration> configClient = (consulConfig) =>
            {
               
                consulConfig.Address = new Uri($"http://{serviceEntity.ConsulIP}:{ serviceEntity.ConsulPort}");
                consulConfig.Datacenter = "dc1";
            };
            //建立连接
            var consulClient = new ConsulClient(configClient);
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康监测，多久进行检查一次
                HTTP = string.Format($"http://{serviceEntity.ip}:{serviceEntity.port}/api/health"),//心跳检测地址
                Timeout = TimeSpan.FromSeconds(5)
            };
            //注册
            var registrtion = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = "zyzService" + Guid.NewGuid().ToString(),//服务编号不可重复
                Name = serviceEntity.ServiceName,//服务名称
                Address = serviceEntity.ip,//ip地址
                Port = serviceEntity.port//端口

            };
            //注册服务
            
            consulClient.Agent.ServiceRegister(registrtion);

            return app;
        }

    }
}
