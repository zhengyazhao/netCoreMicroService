using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 5; i++)
            {
                //Thread t1 = new Thread(ts);
                //t1.Start();
                num();
            }
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine($"Stopwatch总共花费{ ts2.TotalMilliseconds}ms.当前线程id:{Thread.CurrentThread.ManagedThreadId}");
        }

        private void num()
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            long sum = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                sum = sum + i;
            }
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine($"计算结果为:{sum},Stopwatch总共花费{ ts2.TotalMilliseconds}ms.当前线程id:{Thread.CurrentThread.ManagedThreadId}");
        }
        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ThreadStart ts = new ThreadStart(num);
            List<Thread> threadList = new List<Thread>();
            for (int i = 0; i < 5; i++)
            {
                Thread t1 = new Thread(ts);
                threadList.Add(t1);
                t1.Start();

            }
            threadList.ForEach(x => x.Join());
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine($"Stopwatch总共花费{ ts2.TotalMilliseconds}ms.当前线程id:{Thread.CurrentThread.ManagedThreadId}");
        }
        /// <summary>
        /// task执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Action<int, int> action = new Action<int, int>(sum);

            List<Task> taskList = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();
            for (int i = 0; i < 5; i++)
            {          
              //  taskList.Add(Task.Run(() => action(1, 3)));//采用task方式
                taskList.Add(taskFactory.StartNew(() => action(1, 3)));//采用taskfactory方式
               
            }
            
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine($"Stopwatch总共花费{ ts2.TotalMilliseconds}ms.当前线程id:{Thread.CurrentThread.ManagedThreadId}");

        }

        private void sum(int x, int y)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long sum = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                sum = sum + i;
            }
            sw.Stop();
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine($"计算结果为:{sum},Stopwatch总共花费{ ts2.TotalMilliseconds}ms.当前线程id:{Thread.CurrentThread.ManagedThreadId}");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //一元空值检查操作符
            user model = new user();
            model.userName = "test";

            string name = string.Empty;
            string copyName = string.Empty;
            Console.WriteLine($"name为{nameof(WindowsFormsApp1)}");

         
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            ITrackAbnormal ts = new qtimeHold();

            ts.updateWipLot("张三");
           
        }
        /// <summary>
        /// 多线程等待
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

            Console.WriteLine("********************测试***************************");
            var task1 = new Task(() => {
                Console.WriteLine("task1 begin");
                Thread.Sleep(1000);
                Console.WriteLine("task1 end");
            });
            var task2 = new Task(() => {
                Console.WriteLine("task2 begin");
                Thread.Sleep(3000);
                Console.WriteLine("task2 end");
            });
            task1.Start();
            task2.Start();
            var result = task1.ContinueWith<string>(task=> {
                Console.WriteLine("task1 finished!");
                return "This is task result!";
            });
            Console.WriteLine(result.Result.ToString());



        }
    }

}

public class user
    {
        public string userName { get; set; }
    }

