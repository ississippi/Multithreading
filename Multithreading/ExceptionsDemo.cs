using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class ExceptionsDemo
    {
        List<Exception> exceptions = new List<Exception>();
        object lockExceptions = new object();
        
        public void Demo()
        {
            Thread thread1 = new Thread(Work);
            Thread thread2 = new Thread(Work);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            foreach (var ex in exceptions)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void Work()
        {
            try
            {
                throw new InvalidOperationException("An error occured. This is expected.");
            }
            catch (Exception ex)
            {
                lock (lockExceptions)
                {
                    exceptions.Add(ex);
                }
            }

        }
    }
}
