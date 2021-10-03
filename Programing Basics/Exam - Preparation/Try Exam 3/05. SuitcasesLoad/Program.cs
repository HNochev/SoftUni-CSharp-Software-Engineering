using System;

namespace _05._SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int caseCounter = 0;

            while (input != "End")
            {
                double caseVolume = double.Parse(input);
                caseCounter++;
                if (caseCounter % 3 == 0)
                {
                    caseVolume = caseVolume * 1.10;
                }
                if (capacity < caseVolume)
                {
                    Console.WriteLine($"No more space!");
                    caseCounter--;
                    break;
                }
                capacity = capacity - caseVolume;
                input = Console.ReadLine();
            }
            if (input == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {caseCounter} suitcases loaded.");
        }
    }
}
