using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetCorejwt.jwt
{
    public class TokenModel
    {
     
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string UserRole { get; set; }
    }
}
