using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链设计模式
{
  public static class buildFatory
    {
        public static Iaudit BuildIaudit()
        {

            Iaudit director = new director()
            {
                Name = "主管张三"
            };

            Iaudit manage = new manager()
            {
                Name = "经理李四"
            };
            Iaudit inspector = new inspector()
            {
                Name = "总监李四"
            };
            director.parentAudit(manage);
            manage.parentAudit(inspector);
            return director;
        }
    }
}
