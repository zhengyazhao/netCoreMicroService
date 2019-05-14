using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链设计模式
{
    public class director : AuditPersonBase, Iaudit
    {
        private Iaudit audits = null;
        public void audit(int day)
        {
            if (day < 5)
            {
                Console.WriteLine($"************这里是{this.Name}主管审批通过********************");
            }
            else {
                Console.WriteLine($"************主管没有权限去找经理********************");
                this.audits.audit(day);
            }
        }


        public void parentAudit<T>(T model) where T : Iaudit
        {
            this.audits = model;
        }


    }
}
