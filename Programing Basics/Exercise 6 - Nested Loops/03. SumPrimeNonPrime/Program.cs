using System;

namespace _03._SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int simpleSum = 0;
            int complexSum = 0;

            while (command != "stop")
            {
                int numInt = int.Parse(command);
                int counter = 0;
                if (numInt < 0)
                {
                    Console.WriteLine("Number is negative.");
                    numInt = 0;
                }
                for (int i = 1; i <= numInt; i++)
                {
                    if (numInt % i == 0)
                    {
                        counter++;
                    }
                }
                if (counter == 2)
                {
                    simpleSum = simpleSum + numInt;
                }
                else if (counter > 2)
                {
                    complexSum = complexSum + numInt;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {simpleSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {complexSum}");
        }
    }
}
