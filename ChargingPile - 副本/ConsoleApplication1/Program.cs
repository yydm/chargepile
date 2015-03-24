using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
     {
         //声明委托
         public delegate void AsyncEventHandler();
 
         //异步方法
         void Event1()
        {
            Console.WriteLine("Event1 Start");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Event1 End");
        }

        // 同步方法
        void Event2()
        {
            Console.WriteLine("Event2 Start");
            int i=1;
            while(i<1000)
            {
                i=i+1;
                Console.WriteLine("Event2 "+i.ToString());
            }
            Console.WriteLine("Event2 End");
        }

        [STAThread]
        static void Main(string[] args)
        {
            var c = new Program();
            Console.WriteLine("ready");
            var start = DateTime.Now.Ticks;

            //实例委托
            var asy = new AsyncEventHandler(c.Event1);
            //异步调用开始，没有回调函数和AsyncState,都为null
            var ia = asy.BeginInvoke(null, null);
            //同步开始，
            c.Event2();
            //异步结束，若没有结束，一直阻塞到调用完成，在此返回该函数的return，若有返回值。

           
            asy.EndInvoke(ia);

            //都同步的情况。
            //c.Event1();
            //c.Event2();
           
            var end = DateTime.Now.Ticks;
            Console.WriteLine("时间刻度差="+ Convert.ToString(end-start) );
            Console.ReadLine();
        }
    }
}
