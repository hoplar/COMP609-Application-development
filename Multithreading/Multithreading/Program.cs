using System;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        private static readonly object highestNoLock = new object();
        //public static int[] intarr = new int[] { 1, 3, 5, 7, 9 };
        public static int[] intarr = generateArray(10000000);
        public static int highestNo;

        public static int[] generateArray(int count)
        {
            Random random = new Random();
            int[] values = new int[count];

            for (int i = 0; i < count; ++i)
                values[i] = random.Next();

            return values;
        }

        public static void firstHalf()
        {
            int highest = 0;
            for (int i = 0; i < intarr.Length/2; i++)
            {
                if (intarr[i] > highest)
                {
                    highest = intarr[i];
                }
            }
            lock (highestNoLock)
            {
                if (highest > highestNo)
                {
                    highestNo = highest;
                }
            }

        }

        public static void secondHalf()
        {
            int highest = 0;
            for (int i = intarr.Length/2; i < intarr.Length; i++)
            {
                if (intarr[i] > highest)
                {
                    highest = intarr[i];
                }
            }
            lock (highestNoLock)
            {
                if (highest > highestNo)
                {
                    highestNo = highest;
                }
            }
        }

        public static void allofarray()
        {
            int highest = 0;
            for (int i = 0; i < intarr.Length; i++)
            {
                if (intarr[i] > highest)
                {
                    highest = intarr[i];
                }
            }
            if (highest > highestNo)
            {
                highestNo = highest;
            }
        }



        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //allofarray();
            Thread thr1 = new Thread(firstHalf);
            Thread thr2 = new Thread(secondHalf);
            thr1.Start();
            thr2.Start();
            while (thr1.IsAlive || thr2.IsAlive)
            {
                Thread.Sleep(5);
            }

            watch.Stop();
            Console.WriteLine("highest number is: " + highestNo);
            Console.WriteLine($"Total Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}
