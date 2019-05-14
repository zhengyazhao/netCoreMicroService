using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链设计模式
{
    public interface Iaudit
    {
        void audit(int day);

        void parentAudit<T>(T model) where T : Iaudit;

    }
}
