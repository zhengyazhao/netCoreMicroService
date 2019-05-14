using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************************");
            #region 多线程测试
            for (int i = 0; i < 10; i++)
            {

                new Action(() => {

                    UserSingleton userSingleton = UserSingleton.GetInstance();
                    userSingleton.getUserList();
                }).BeginInvoke(null, null);
            }
            #endregion

            #region 多线程测试1
            for (int i = 0; i < 10; i++)
            {

                new Action(() => {

                    UserStaticSingleton userSingleton = UserStaticSingleton.GetInstance();
                    userSingleton.getUserList();
                }).BeginInvoke(null, null);
            }
            #endregion

            Console.ReadLine();
        }
    }
}
