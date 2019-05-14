using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.config
{
    public class AppSettings
    {
        public RedisCaching RedisCaching { get; set; }
    }
    /// <summary>
    /// redis缓存信息
    /// </summary>
    public class RedisCaching
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool enabled { get; set; } = true;
        /// <summary>
        /// 链接信息
        /// </summary>
        public string ConnctionString { get; set; }
    }
}
