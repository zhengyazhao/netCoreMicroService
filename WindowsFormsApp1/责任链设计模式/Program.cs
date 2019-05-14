using System;

namespace 责任链设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************请假流程****************************88");

            person person = new person()
            {
                name = "大黄",
                content = "请假去打dota",
                date = 10
            };

            Console.WriteLine($"{person.name}，想要请假{person.content}天");
            Iaudit auditModel = buildFatory.BuildIaudit();

            auditModel.audit(person.date);

            //if (person.date <5)
            //{
            //    Console.WriteLine($"主管1同意");
            //}
            //else
            //{
            //    Console.WriteLine($"--------------找经理审批主管1做不了主-----------");
            //    if (person.date <= 10)
            //    {

            //        Console.WriteLine($"经理2同意");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"--------------找总监审批经理2做不了主-----------");
            //    }
            //}

            Console.ReadLine();

        }
    }
}
