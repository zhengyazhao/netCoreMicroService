using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 享元设计模式
{
   public class xuemo: personBase
    {
        public xuemo()
        {
            Thread.Sleep(1000);
            Console.WriteLine("选择了血魔");
        }
    }

}
