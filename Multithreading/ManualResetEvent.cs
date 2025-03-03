using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class ManualResetEventDemo
    {
        ManualResetEventSlim manualResetEvent = new ManualResetEventSlim(false);

        public void Demo()
        {
            Console.WriteLine("Press enter to release all threads...");
            try
            {
                for (int i = 1; i <= 3; i++)
                {
                    Thread thread = new Thread(Work);
                    thread.Name = $"Thread {i}";
                    thread.Start();
                }


                Console.ReadLine();

                manualResetEvent.Set();

                Console.ReadLine();
            }
            finally
            {
                manualResetEvent.Dispose();
            }
        }

        void Work()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for the signal...");
            manualResetEvent.Wait();
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} has been released.");
        }
    }
}
