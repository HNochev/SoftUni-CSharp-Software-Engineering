using System;
using System.Linq;

namespace _05._AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;
            
            while (input != "NoMoreMoney")
            {
                double number = double.Parse(input);
                if(number >= 0)
                {
                    sum = sum + number;
                    Console.WriteLine($"Increase: {number:f2}");
                input = Console.ReadLine();
                }    
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
            }
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
