using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetCorejwt.jwt
{
    public  class JwtTokenHelper
    {
       static  string SecretKey = "DTGK";
        public static string GetToken(TokenModel model)
        {
          
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var payload = new Dictionary<string, dynamic>();
            payload.Add("userName", model.UserName);
            payload.Add("userPwd", model.UserPwd);
            payload.Add("userRole", model.UserRole);
            var token = encoder.Encode(payload, SecretKey);
            return token;
        }

        public static TokenModel unToken(string token)
        {
            TokenModel model = new TokenModel();
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            var json = decoder.Decode(token, SecretKey, verify: true);
            dynamic payload = JsonConvert.DeserializeObject<dynamic>(json);
            model.UserName  = payload.userName;
            model.UserPwd = payload.userPwd;
            return model;
        }
    }
}
