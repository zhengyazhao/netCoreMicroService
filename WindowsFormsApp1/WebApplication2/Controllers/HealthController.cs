using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class HealthController : Controller
    {
        [HttpGet]
        /// <summary>
        /// consul心跳检测
        /// </summary>
        /// <returns></returns>
        public IActionResult get() => Ok("ok");
    }
}