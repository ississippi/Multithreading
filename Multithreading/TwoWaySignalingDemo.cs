﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class TwoWaySignalingDemo
    {

        Queue<int> queue = new Queue<int>();

        ManualResetEventSlim consumeEvent = new ManualResetEventSlim(false);
        ManualResetEventSlim produceEvent = new ManualResetEventSlim(true);
        int consumerCount = 0;
        object lockConsumerCount = new object();

        Thread[] consumerThreads = new Thread[3];

        public void Demo()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    consumerThreads[i] = new Thread(Consume);
                    consumerThreads[i].Name = $"Consumer {i + 1}";
                    consumerThreads[i].Start();
                }
                // Producer
                while (true)
                {
                    produceEvent.Wait();
                    produceEvent.Reset();

                    Console.WriteLine("To produce, enter 'p'");
                    var input = Console.ReadLine() ?? "";

                    if (input.ToLower() == "p")
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            queue.Enqueue(i);
                            Console.WriteLine($"Produced: {i}");
                        }

                        consumeEvent.Set();
                    }
                }
            }
            finally
            {
                consumeEvent.Dispose();
                produceEvent.Dispose();
            }
        }

        // Consumer's behavior

        void Consume()
        {
            while (true)
            {
                consumeEvent.Wait();

                while (queue.TryDequeue(out int item))
                {
                    // work on the items produced
                    Thread.Sleep(500);
                    Console.WriteLine($"Consumed: {item} from thread: {Thread.CurrentThread.Name}");
                }

                lock (lockConsumerCount)
                {
                    consumerCount++;

                    if (consumerCount == 3)
                    {
                        consumeEvent.Reset();
                        produceEvent.Set();
                        consumerCount = 0;

                        Console.WriteLine("****************");
                        Console.WriteLine("**** More Please! *****");
                        Console.WriteLine("****************");
                    }
                }
            }
        }

    }
}
