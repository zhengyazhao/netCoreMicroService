using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰器模式.equipment
{
    /// <summary>
    /// 装备装饰器
    /// </summary>
    public class HY : arms
    {
        private IRole _role = null;
        public HY(IRole role)
            : base(role)
        {
            _role = role;
        }
        public override void show()
        {
            this._role.show();
            Console.WriteLine("我获取了一个辉耀，附近敌人每秒减血100点");
        }
    }
}
