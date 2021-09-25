using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double budget = 0;
            double money = 0;
            double sum = 0;

            while(destination!="End")
            {
                budget = double.Parse(Console.ReadLine());
                while (sum < budget)
                {
                    money = double.Parse(Console.ReadLine());
                    sum = sum + money;
                }
                if (sum >= budget)
                {
                    Console.WriteLine($"Going to {destination}!");
                    sum = 0;
                }
                destination = Console.ReadLine();
            }
        }
    }
}
