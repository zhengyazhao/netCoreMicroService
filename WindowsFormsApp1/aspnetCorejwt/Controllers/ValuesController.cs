using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetCorejwt.jwt;
using Microsoft.AspNetCore.Mvc;

namespace aspnetCorejwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
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
        [HttpGet("requestToken")]
        public string requestToken(string userName, string password)
        {

            string result = string.Empty;
            if (userName == "zzz" && password == "111")
            {
                TokenModel model = new TokenModel();
                model.UserName = userName;
                model.UserPwd = password;
                result = JwtTokenHelper.GetToken(model);

            }
            else
            {
                result = "用户名 or  密码错误!~~";

            }
            return result;
        }
        [HttpGet("VerificationToken")]
        public string VerificationToken()
        {
            string token=HttpContext.Request.Headers["token"].FirstOrDefault();

          TokenModel model=  JwtTokenHelper.unToken(token);
            return token +"用戶名:"+ model.UserName+"密码:"+model.UserPwd;

        }
    }
}
