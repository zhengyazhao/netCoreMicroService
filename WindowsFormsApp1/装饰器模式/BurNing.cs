using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰器模式
{
    /// <summary>
    /// 流量法师角色
    /// </summary>
    public class BurNing : IRole
    {
        
     
        public override void show()
        {
            Console.WriteLine("我是敌法师，下面是买装备过程！~");
        }
    }

    public class BurNingeqment : IRole
    {


        public override void show()
        {
            Console.WriteLine("我是敌法师，下面是买装备过程！~");
          
        }
    }
}
