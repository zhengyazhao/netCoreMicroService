using System;
using System.Net.Http;
using IdentityModel.Client;
namespace TokenDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            var client = new HttpClient();
            var tokenrespose = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                //indentity地址
                Address = "http://localhost:3322/connect/token",
             
                ClientId = "client",//服务id
                ClientSecret = "123454",//秘钥
                Scope = "api1"//可访问的服务

            }).Result;
            //判断是否异常
            if (tokenrespose.IsError)
            {
                Console.WriteLine(tokenrespose.Error);
            }
            
            var httpclient = new HttpClient();
            httpclient.SetBearerToken(tokenrespose.AccessToken);//添加accesstoken

            var response = httpclient.GetAsync("http://localhost:5001/api/Values/send").Result;
            //是否成功
            if (response.IsSuccessStatusCode)
            {
                //打印结果
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            Console.ReadLine();
        }
       
    }
}
