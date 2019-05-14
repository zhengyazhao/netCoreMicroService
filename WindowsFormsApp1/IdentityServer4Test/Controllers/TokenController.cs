using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace IdentityServer4Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        public async Task<JObject> Get()
        {
            var disco = await DiscoveryClient.GetAsync($"{Request.Scheme}://{Request.Host}");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return null;
            }

            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return null;
            }

            return tokenResponse.Json;
        }
        [HttpGet("/GetJ")]
        public async Task<JObject> GetjAsync()
        {
            // call api
            var client = new HttpClient();
            var disco = await client.RevokeTokenAsync(new TokenRevocationRequest
            {
                Address = $"{Request.Scheme}://{Request.Host}",
                ClientId = "client",
                ClientSecret = "laozheng",
                

            });
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return null;
            }
        
            return disco.Json;
        }
    }
}