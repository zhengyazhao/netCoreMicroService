using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 享元设计模式
{
   public class pis: personBase
    {
        public pis()
        {
            Thread.Sleep(1000);
            Console.WriteLine("选择了影魔！~");
        }
    }
}
