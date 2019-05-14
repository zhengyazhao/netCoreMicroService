﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.consulRegin
{
  public  class ConsulServiceOption
    {

        public string ServiceName { get; set; }

        public string Version { get; set; }

        public ConsulRegistryConfig Consul { get; set; }

        public string HealthCheckTemplate { get; set; }

        public string[] Endpoints { get; set; }
    }
}
