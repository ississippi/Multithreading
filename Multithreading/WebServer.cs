using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class WebServer
    {
        int availableTickets = 10;
        object ticketsLock = new object();
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
                    Thread processingThread = new Thread(() => ProcessBooking(input));
                    processingThread.Start();  
                }
                Thread.Sleep(1000);

            }
        }

        void ProcessBooking(string input)
        {
            // Simulate processing time
            //Thread.Sleep(2000);

            lock(ticketsLock)
            {
                if (input.ToLower() == "b")
                {
                    if (availableTickets > 0)
                    {
                        availableTickets--;
                        Console.WriteLine();
                        Console.WriteLine($"You seat is booked. {availableTickets} seats are still available.");
                    }
                    else
                    {
                        Console.WriteLine($"No tickets are available.");
                    }

                }
                else if (input.ToLower() == "c")
                {
                    if (availableTickets < 10)
                    {
                        availableTickets++;
                        Console.WriteLine();
                        Console.WriteLine($"You booking is cancelled. {availableTickets} seats are still available.");
                    }
                    else
                    {
                        Console.WriteLine($"You cannot cancel a booking at this time.");
                    }
                }
            }
        }
    }
}
