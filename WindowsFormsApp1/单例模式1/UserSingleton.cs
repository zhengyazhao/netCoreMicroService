using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 单例模式1
{
    public class UserSingleton
    {

        private static UserSingleton userSingleton = null;
        private static object obj = new object();
        private UserSingleton()
        {
            Console.WriteLine($"我的线程id:{Thread.CurrentThread.ManagedThreadId}");

        }
        public static UserSingleton GetInstance()
        {
            if (userSingleton == null)
            {
                lock (obj)
                {
                    if (userSingleton == null)
                    {

                        userSingleton = new UserSingleton();
                    }

                }
            }
            return userSingleton;
        }
        public void getUserList()
        {
            Console.WriteLine("我是影魔");

        }
    }
}
