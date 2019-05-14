using System;

namespace 字符串类型对比是否相等问题
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************");
            string str = "李逵";
            string str1 = "李逵";
            Console.WriteLine($"str==str1的比较结果为                                   ：{str==str1}");
            Console.WriteLine($"str.Equals(str1)的比较结果为                            ：{str.Equals(str1)}");
            Console.WriteLine($"object.ReferenceEquals(str,str1)的比较结果为            ：{object.ReferenceEquals(str,str1)}");

            string str2 = string.Format($"李{"逵"}");
            Console.WriteLine($"str.Equals(str1)的比较结果为                            ：{str.Equals(str2)}");
            Console.WriteLine($"object.ReferenceEquals(str,str2)的比较结果为            ：{object.ReferenceEquals(str, str2)}");

            Console.ReadLine();


        }
    }
}
