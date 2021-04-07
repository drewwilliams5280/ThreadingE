using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingE
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Console.WriteLine("Hello World! 1");
              Thread.Sleep(1000);
              Console.WriteLine("Hello World! 2");
              Thread.Sleep(1000);
              Console.WriteLine("Hello World! 3");
              Thread.Sleep(1000);
              Console.WriteLine("Hello World! 4"); */

            /* new Thread(() =>
             {
                 Thread.Sleep(1000);
                 Console.WriteLine("thread 1");
             }).Start();

             new Thread(() =>
             {
                 Thread.Sleep(1000);
                 Console.WriteLine("thread 2");
             }).Start();

             new Thread(() =>
             {
                 Thread.Sleep(1000);
                 Console.WriteLine("thread 3");
             }).Start();
            */


             new Thread(() =>
             {
                 Thread.Sleep(1000);
                 Console.WriteLine("thread 4");
             })
             { IsBackground = true }.Start(); 


            Enumerable.Range(0, 1000).ToList().ForEach(f =>
             {
                 ThreadPool.QueueUserWorkItem((o) =>
                 {
                     Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                     Thread.Sleep(1000);

                     Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                 });
             });

            Console.ReadLine();
        }
    }
}
