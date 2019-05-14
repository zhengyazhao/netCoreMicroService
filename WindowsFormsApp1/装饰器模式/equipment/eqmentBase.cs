using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰器模式.equipment
{
    /// <summary>
    /// 装备装饰器
    /// </summary>
    public class eqmentBase : arms
    {
        private IRole _role = null;
        public eqmentBase(IRole role)
            : base(role)
        {
            _role = role;
        }
        public override void show()
        {
            this._role.show();
            Console.WriteLine("我获取了一个吸血头盔，吸血10%");
        }
    }
}
