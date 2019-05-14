using System;

namespace 装饰器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************************");


            {
                IRole di = new BurNing();
                di = new arms(di);
                di = new equipment.eqmentBase(di);
                di = new equipment.HY(di);
                di.show();
            }
            {
                //Pis person = new Pis();
                //person.show();
                //BurNing burNing = new BurNing();
                //burNing.show();
            }
            Console.ReadLine();
        }
    }
}
