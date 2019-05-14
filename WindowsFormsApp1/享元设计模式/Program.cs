using System;
using System.Threading.Tasks;

namespace 享元设计模式
{
    class Program
    {
        static void Main(string[] args)
        {


            for (int i = 0; i < 5; i++)
            {
                Task.Run(() =>
                {
                    show();
                    show1();
                });
            }
            Console.ReadLine();

        }

        public  static void show1()
        {
            Console.WriteLine("********************我方选择-享元设计模式演示***********************");

            //liulang l = new liulang();
            //pis p = new pis();
            //smallBlack smallBlack = new smallBlack();
            //xuemo xuemo = new xuemo();
            FlyweightFactory.BuildPersion(personEnum.liulang);
            FlyweightFactory.BuildPersion(personEnum.pis);
            FlyweightFactory.BuildPersion(personEnum.xuemo);
            FlyweightFactory.BuildPersion(personEnum.smallBlack);
            Console.WriteLine($"我方选择：小黑、流浪、血魔、影魔");
        }
        public static void show()
        {
            Console.WriteLine("********************敌方选择-享元设计模式演示***********************");

            //liulang l = new liulang();
            //pis p = new pis();
            //smallBlack smallBlack = new smallBlack();
            //xuemo xuemo = new xuemo();
            FlyweightFactory.BuildPersion(personEnum.liulang);
            FlyweightFactory.BuildPersion(personEnum.pis);
            FlyweightFactory.BuildPersion(personEnum.xuemo);
            FlyweightFactory.BuildPersion(personEnum.smallBlack);
            Console.WriteLine($"敌方选择：小黑、流浪、血魔、影魔");
        }

    }
}
