using System;
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

             new Thread(() =>
             {
                 Thread.Sleep(1000);
                 Console.WriteLine("thread 4");
             }).Start(); */

            var taskCompletionSource = new TaskCompletionSource<bool>();

            var thread = new Thread(() =>
            {
                Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                Thread.Sleep(1000);
                taskCompletionSource.TrySetResult(true);
                Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
            });
            
            thread.Start();
            var test = taskCompletionSource.Task.Result;
            Console.WriteLine(test);
        }
    }
}
