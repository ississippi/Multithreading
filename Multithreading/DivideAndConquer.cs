using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    internal class DivideAndConquer
    {
        int[] _array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public void Demo()
        {

            int sum = 0;
            int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;


            var startTime = DateTime.Now;

            var numOfThreads = 4;
            var segmentLength = _array.Length / numOfThreads;

            Thread[] threads = new Thread[numOfThreads];
            threads[0] = new Thread(() => { sum1 = SumSegment(0, segmentLength); });
            threads[1] = new Thread(() => { sum2 = SumSegment(segmentLength, 2 * segmentLength); });
            threads[2] = new Thread(() => { sum3 = SumSegment(2 * segmentLength, 3 * segmentLength); });
            threads[3] = new Thread(() => { sum4 = SumSegment(3 * segmentLength, 4 * segmentLength); });

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            //foreach (var num in _array)
            //{
            //    Thread.Sleep(100);
            //    sum += num;
            //}

            var endTime = DateTime.Now;
            var timespan = endTime - startTime;

            Console.WriteLine($"The sum is {sum}.");
            Console.WriteLine($"The time it takes: {timespan.TotalMilliseconds}");
        }

        int SumSegment(int start, int end)
        {
            int segmentSum = 0;
            for (int i = start; i < end; i++)
            {
                Thread.Sleep(100);
                segmentSum += _array[i];
            }

            return segmentSum;
        }
    }
}
