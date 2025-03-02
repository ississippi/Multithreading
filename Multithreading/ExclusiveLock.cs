using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class ExclusiveLock
    {
        int counter = 0;

        object counterLock = new object(); // C# 8 and below
        //Lock counterLock = new Lock();   // C# 9

        public void Demo()
        {
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);
            thread1.Start();
            thread2.Start();


            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Final counter value is: {counter}");
        }
        
        
        void IncrementCounter()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (counterLock)
                {
                    counter = counter + 1;
                }
            }
        }

    }
}
