using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int targets = 0;
            int originalN = n;

            while(n>=m)
            {
                if (n == originalN / 2 && y > 0)
                {
                    n = n / y;
                    if(n<m)
                    {
                        break;
                    }
                }

                n = n - m;
                targets++;
            }
            Console.WriteLine(n);
            Console.WriteLine(targets);
        }
    }
}
