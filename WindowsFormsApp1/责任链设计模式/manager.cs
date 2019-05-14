using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链设计模式
{
   public class manager : AuditPersonBase, Iaudit
    {
        private Iaudit audits = null;
        public void audit(int day)
        {
            if (day < 10)
            {
                Console.WriteLine($"************这里是{this.Name}经理审批通过********************");
            }
            else
            {
                Console.WriteLine($"************经理没有权限去总监********************");
                this.audits.audit(day);
            }
        }

        public void parentAudit<T>(T model) where T : Iaudit
        {
            this.audits = model;
        }

    }

}
