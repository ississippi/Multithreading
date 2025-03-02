using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class WebServer
    {
        // this Queue class is not thread safe:
        Queue<string> requestQueue = new Queue<string>();

        public void SubmitRequest(string request)
        {
            requestQueue.Enqueue(request);
        }

        public void MonitorQueue()
        {
            while (true)
            {
                if (requestQueue.Count > 0)
                {
                    string? input = requestQueue.Dequeue();
                    Thread processingThread = new Thread(() => ProcessInput(input));
                    processingThread.Start();  
                }
                Thread.Sleep(1000);

            }
        }

        void ProcessInput(string input)
        {
            // Simulate processing time
            Thread.Sleep(2000);
            Console.WriteLine($"Processed Input: {input}");
        }
    }
}
