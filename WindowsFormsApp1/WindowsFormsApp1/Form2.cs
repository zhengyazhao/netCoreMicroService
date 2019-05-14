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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ThreadPool.QueueUserWorkItem(x => num());
            //ThreadPool.QueueUserWorkItem(x => num());
            //ThreadPool.QueueUserWorkItem(x => num());
            //ThreadPool.QueueUserWorkItem(x => num());
            //ThreadPool.QueueUserWorkItem(x => num());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Action a = new Action(num);
          

            List<Task> taskList = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                Task t = new Task(a);
                taskList.Add(t);
                t.Start();

            }
            taskList.ForEach(x => x.Wait());
            TimeSpan ts2 = sw.Elapsed;
            Console.WriteLine($"Stopwatch总共花费{ ts2.TotalMilliseconds}ms.当前线程id:{Thread.CurrentThread.ManagedThreadId}");

        }

        public static void num()
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
    }
}
