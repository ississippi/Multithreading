using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class BasicSyntax
    {
        void WriteThreadId()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("TID: " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(50);
            }
        }
        public void Demo()
        {
            Thread thread1 = new Thread(WriteThreadId);
            Thread thread2 = new Thread(WriteThreadId);

            thread1.Priority = ThreadPriority.Highest;
            thread2.Priority = ThreadPriority.Lowest;

            Thread.CurrentThread.Priority = ThreadPriority.Normal;

            thread1.Start();
            thread2.Start();

            WriteThreadId();
        }
    }
}
