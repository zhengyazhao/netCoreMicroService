using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsulServer
{
    /// <summary>
    /// config单例
    /// </summary>
    public class ConfigSingleton
    {


        private static IConfiguration _appSection = null;
        private static object obj = new object();

        public static void setConfigSingleton(IConfiguration configuration)
        {
            //双if加lock方式config赋值
            if (_appSection == null)
            {
                lock (obj)
                {
                    if (_appSection == null)
                    {
                        _appSection = configuration;
                    }
                }
            }
        }

        public static IConfiguration getConfigSingleton()
        {
            return _appSection;
        }

    }
}
