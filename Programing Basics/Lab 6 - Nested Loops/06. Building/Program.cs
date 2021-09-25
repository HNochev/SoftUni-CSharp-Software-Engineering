using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int levels = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            int lastLevel = levels;

            for (int i = levels; i > 0; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if(i == lastLevel)
                    {
                        Console.Write($"L{i}{j} ");
                        continue;
                    }
                    if(i%2==0)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else
                    {
                        Console.Write($"A{i}{j} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
