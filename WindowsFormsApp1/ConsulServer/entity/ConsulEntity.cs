using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsulServer.entity
{
    /// <summary>
    /// 实体类
    /// </summary>
    public class ConsulEntity
    {
        /// <summary>
        /// 本机ip
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 本机端口号
        /// </summary>

        public int port { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string ConsulIP { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public int ConsulPort { get; set; }
    }
}
