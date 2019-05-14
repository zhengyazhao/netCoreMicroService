using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace 行锁
{
    class Program
    {
        static void Main(string[] args)
        {
            new Thread(() => thread1()).Start();
            new Thread(() => thread2()).Start();
            Console.WriteLine("*********主线程查询中******************");

            Thread.Sleep(3000);
            string sql = string.Format($"select userid from sys_user where userseq=10018 ");
            SqlHelper.ExecteNonQuery(CommandType.Text, sql);
            Console.WriteLine("*********主线程查询完成******************");
            //thread1();
            Console.ReadLine();
        }

       static  void thread1()
        {
            Console.WriteLine("开始修改线程");
            using (TransactionScope scope = new TransactionScope())
            {
                Console.WriteLine("*********修改中******************");
                string sql = string.Format($"update sys_user set userid='{"zyz2"}' where  userseq=10018");
                SqlHelper.ExecteNonQuery(CommandType.Text,sql);
                Thread.Sleep(15000);
                scope.Complete();
                Console.WriteLine("*********修改完成******************");
            }
        }

      static   void thread()
        {
            Console.WriteLine("开始查询线程事务");
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                Thread.Sleep(1000);
                Console.WriteLine("*********查询中******************");

                string sql = string.Format($"select userid from sys_user where userseq=10018 ");
              object obj=  SqlHelper.ExecuteScalar( CommandType.Text,sql);
                Console.WriteLine("********查询完成******************");
                scope.Complete();
            }
        }

        static void thread2()
        {
            Console.WriteLine("开始查询线程事务");
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                Console.WriteLine("*********修改中2******************");
                Thread.Sleep(1000);
                
                string sql = string.Format($"update sys_user set userid='{"zyz3"}' where  userseq=10018");
                SqlHelper.ExecteNonQuery(CommandType.Text, sql);
                scope.Complete();
               
                Console.WriteLine("*********修改完成2******************");
            }
        }
    }
}
