using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰器模式
{
    /// <summary>
    /// 敌法师假腿装饰器
    /// </summary>
    public class arms : IRole
    {
        private IRole _burNing = null;
        public arms(IRole burNing)
        {
            this._burNing = burNing;
        }

        public override void show()
        {
            _burNing.show();
            Console.WriteLine("敌法师装备了假腿，力量+10~");

        }
    }
}
