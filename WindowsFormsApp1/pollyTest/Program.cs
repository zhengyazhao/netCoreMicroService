using Polly;
using Polly.Timeout;
using System;
using System.Threading;

namespace pollyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ///handle里是捕捉的错误类型
           // #region 服务降级
           // ISyncPolicy policyJJ = Policy.Handle<ArgumentException>()
           ////当出现故障，则进入降级
           //.Fallback(() =>
           //{
           //    Console.WriteLine("出现故障进行降级");
           //});

           // policyJJ.Execute(() =>
           // {
           //     Console.WriteLine("开始执行");
           //     throw new ArgumentException("hello");
           //     Console.WriteLine("结束");
           // });


           // #endregion
           // #region 服务重试
           // //retry ：重试次数


           // ISyncPolicy policyCS = Policy.Handle<Exception>().Retry(5);


           // try
           // {
           //     policyCS.Execute(() =>
           //     {
           //         Console.WriteLine("开始尝试连接主机");
           //         if (DateTime.Now.Second % 20 != 0)
           //         {
           //             throw new Exception("服务器宕机！~~~~");
           //         }
           //         Console.WriteLine("结束尝试连接");
           //     });
           // }
           // catch (Exception ex)
           // {

           //     Console.WriteLine("远程主机连接失败，错误消息: " + ex.Message);
           // }

           // #endregion
           // #region 短路保护
           // ///CircuitBreaker(重试次数，间隔10秒后在进行重试)
           // ISyncPolicy policy = Policy.Handle<Exception>()
           //     .CircuitBreaker(6, TimeSpan.FromSeconds(10));
           // while (true)
           // {
           //     try
           //     {
           //         policyJJ.Execute(() =>
           //         {
           //             Console.WriteLine("开始登陆服务器。");
           //             throw new Exception("服务器人多请稍后再试~~~~");
           //             Console.WriteLine("Job End");
           //         });
           //     }
           //     catch (Exception ex)
           //     {
           //         Console.WriteLine("登陆失败 : " + ex.Message);
           //     }

           //     Thread.Sleep(500);
           // }

           // #endregion

            #region 服务策略封装
            ///handle里是捕捉的错误类型

            try
            {
                ISyncPolicy policyJiangji = Policy.Handle<TimeoutRejectedException>()
               //当出现故障，则进入降级
               .Fallback(() =>
               {
                   Console.WriteLine("出现故障进行降级");
               });

                //policyJJ.Execute(() =>
                //{
                //    Console.WriteLine("开始执行");
                //    throw new ArgumentException("hello");
                //    Console.WriteLine("结束");
                //});

                ISyncPolicy policyTimeout = Policy.Timeout(3, Polly.Timeout.TimeoutStrategy.Pessimistic);
                ISyncPolicy mainPolicy = Policy.Wrap(policyJiangji, policyTimeout);
                mainPolicy.Execute(() =>
                {
                    Console.WriteLine("开始登陆");
                    Thread.Sleep(5000);
                    //throw new Exception();
                    Console.WriteLine("登陆完成");
                });
            }

            catch (Exception ex)
            {
                Console.WriteLine("登陆失败,错误消息:" + ex.Message);
            }
            #endregion
            Console.ReadLine();
        }
    }
}
