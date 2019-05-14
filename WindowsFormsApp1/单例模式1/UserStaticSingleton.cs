using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式1
{
    public class UserStaticSingleton
    {

        private static UserStaticSingleton userSingleton = null;
        static UserStaticSingleton()
        {
            userSingleton = new UserStaticSingleton();
        }
        public static UserStaticSingleton GetInstance()
        {
            return userSingleton;
        }
        public void getUserList()
        {
            Console.WriteLine("我是影魔");

        }
    }
}
