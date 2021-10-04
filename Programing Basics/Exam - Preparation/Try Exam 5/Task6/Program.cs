using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int a = k; a <= 8; a++)
            {
                if (a % 2 == 0)
                {
                    for (int j = 9; j >= l; j--)
                    {
                        if (j % 2 == 1)
                        {
                            for (int b = m; b <= 8; b++)
                            {
                                if (b % 2 == 0)
                                {
                                    for (int i = 9; i >= n; i--)
                                    {
                                        if (i % 2 == 1)
                                        {
                                            if (a == b && j == i)
                                            {
                                                Console.WriteLine("Cannot change the same player.");
                                                continue;
                                            }
                                            Console.WriteLine($"{a}{j} - {b}{i}");
                                            counter++;
                                            if(counter == 6)
                                            {
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
