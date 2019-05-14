using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Test.IndntityConfig
{
    public class IdentityServerConfig
    {
        /// <summary>
        /// 添加api资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","My Api")
            };
        }
        /// <summary>
        /// 添加客户端，定义一个可以访问此api的客户端
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
                {
                    new Client
                    {
                        ///
                        ClientId = "client",

                        // 没有交互性用户，使用 客户端模式 进行身份验证。
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                       
                        // 用于认证的密码
                        ClientSecrets =
                        {
                            new Secret("laozheng".Sha256())
                        },
                        // 客户端有权访问的范围（Scopes）
                       
                    AllowedScopes =
                    {
                        "api1"
                    }
                    }
                    //,
                    //new Client
                    //{
                    //    ClientId = "client1",

                        
                    //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                       
                    //    // 用于认证的密码
                    //    ClientSecrets =
                    //    {
                    //        new Secret("laozheng".Sha256())
                    //    },
                    //    //RequireClientSecret=false,
                    //    // 客户端有权访问的范围（Scopes）
                    //    AllowedScopes = { "api1" }
                    //}
                };

        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser> {
                new TestUser{
                    SubjectId="1",
                    Password="111",
                    Username="111",
                }
            };
        }
    }
}
