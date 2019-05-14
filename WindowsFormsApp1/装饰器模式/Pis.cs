
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 装饰器模式
{
    public class Pis: IRole
    {
        public override void show()
        {
            Console.WriteLine("我是dota里的影魔,开始买装备！~~");
        }
    }


}