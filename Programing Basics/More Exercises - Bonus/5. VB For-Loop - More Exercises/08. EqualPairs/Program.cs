using System;

namespace _08._EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double pSum = 0;
            double nextSum = 0;
            double diff = 0;
            double maxDiff = double.MinValue;

            for (int i = 0; i < n; i++)
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());

                pSum = a + b;
                if (nextSum == 0)
                {
                    nextSum = pSum;
                }
                if (pSum != nextSum)
                {
                    diff = Math.Abs(pSum - nextSum);
                    if(diff>maxDiff)
                    {
                        maxDiff = diff;
                    }
                }

                nextSum = pSum;
            }
            if (pSum == nextSum && diff == 0)
            {
                Console.WriteLine($"Yes, value={nextSum}");
            }
            if (diff != 0)
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
