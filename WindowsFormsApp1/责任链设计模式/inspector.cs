using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链设计模式
{
    public class inspector : AuditPersonBase, Iaudit
    {
        private Iaudit audits=null;
        public void audit(int day)
        {
            if (day < 20)
            {
                Console.WriteLine($"************这里是{this.Name}总监审批通过********************");
            }
            else
            {
                Console.WriteLine($"************总监没有权限去老总********************");
                this.audits.audit(day);
            }
        }
        public void parentAudit<T>(T model)where T:Iaudit
        {
            this.audits = model;

        }


    }

}
