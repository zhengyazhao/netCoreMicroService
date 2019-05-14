using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using WebApplication1.redis;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
           public ValuesController()
        {
      
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        /// <summary>
        /// 获取两个数字的和是多少
        /// </summary>
        /// <remarks>
        /// 例子：
        /// Get api/values/sum?a=3b=5
        /// </remarks>
        /// <param name="model">用户实体类</param>
        /// <returns>返回值</returns>
        [Route("sum")]
        [HttpGet]
        public int sum([FromHeader]UserModel model)
        {
            int num = model.UserCount + model.UserScore;
            int result = 0;
            //for (int i = 0; i < 100_00_000; i++)
            //{


            RedisHelper1 redisHelper = new RedisHelper1();
            /***************插入list******************************/
            List<string> list = new List<string>();
            //for (int i = 0; i < 5; i++)
            //{

            //    if (_redisCacheManager.Exists($"userList{nameof(ValuesController)}"))
            //    {
            //        list = _redisCacheManager.Get<List<string>>($"userList{nameof(ValuesController)}");
            //        System.Diagnostics.Debug.WriteLine(string.Join(',',list.ToArray()));
            //    }
            //    else
            //    {
            //        List<string> listItem = new List<string>();
            //        listItem.Add("用户名");
            //        listItem.Add("密码");
            //        listItem.Add("性别");
            //        Thread.Sleep(3000);
            //        _redisCacheManager.Set($"userList{nameof(ValuesController)}", listItem);
            //    }
            //}

            {

            }
            /***************插入字符串******************************/
            //string test = string.Empty;
            //for (int i = 0; i < 5; i++)
            //{
            //    if (_redisCacheManager.Exists($"cstNum1:{nameof(ValuesController)}"))
            //    {
            //        test = _redisCacheManager.Get<string>($"cstNum1:{nameof(ValuesController)}").ToString();
            //        Console.WriteLine(_redisCacheManager.Get<string>($"cstNum1:{nameof(ValuesController)}"));
            //    }
            //    else
            //    {
            //        Thread.Sleep(3000);
            //        _redisCacheManager.Set($"cstNum1:{nameof(ValuesController)}", "测试学习哈哈哈");
            //    }
            //}
            //for (int i = 0; i < 5; i++)
            //{
            //    if (redisHelper.KeyExists($"cstNum1:{nameof(ValuesController)}"))
            //    {
            //        var result1 =redisHelper.StringGet($"cstNum1:{nameof(ValuesController)}");
            //    }
            //    else
            //    {
            //        Thread.Sleep(3000);
            //        RedisHelper.Set($"cstNum1:{nameof(ValuesController)}", 5.ToString());
            //    }
            //}

            //if (RedisHelper.Exists($"cstNum:{ nameof(ValuesController)}"))
            //{
            //result = int.Parse(RedisHelper.Get($"cstNum:{nameof(ValuesController)}").ToString());
            //}
            //else
            //{
            //RedisHelper.Set($"cstNum:{ nameof(ValuesController)}", a + b);
            //}
            //}


            return num;
        }

        [Route("TestHash")]
        [HttpGet]
        public void testHash()
        {
            int? s = null;
            float? cc = null;
            if (!s.HasValue)
            {
                
                Debug.WriteLine("int没有值");
            }
            if (!cc.HasValue)
            {
                Debug.WriteLine("float没有值");
            }
          
        }

    }

    public class UserModel
    {
        public int UserCount { get; set; }

        public int UserScore { get; set; }
    }
}
