using System;

namespace _04._Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for(int k = 1; k <= number; k = k * 2 + 1)
            {
                Console.WriteLine(k);
            }
        }
    }
}
