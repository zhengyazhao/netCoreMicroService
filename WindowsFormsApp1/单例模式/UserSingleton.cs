using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 单例模式
{
    public class UserSingleton
    {

       private static UserSingleton userSingleton =null;
        private UserSingleton()
        {
            Console.WriteLine($"我的线程号:{Thread.GetCurrentProcessorId()};id:{Thread.CurrentThread.ManagedThreadId}");

        }
        public static UserSingleton GetInstance()
        {
            if (userSingleton == null)
            {
                   userSingleton = new UserSingleton();
            }
            return userSingleton;
        }
        public void getUserList()
        {
            Console.WriteLine("我是影魔");
        
        }
    }
}
