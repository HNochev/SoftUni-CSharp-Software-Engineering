using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            for (; m >= n; m--)
            {

                if (m % 2 == 0 && m % 3 == 0)
                {
                    if (m == s)
                    {
                        return;
                    }
                    Console.Write($"{m} ");
                }
            }
        }
    }
}
