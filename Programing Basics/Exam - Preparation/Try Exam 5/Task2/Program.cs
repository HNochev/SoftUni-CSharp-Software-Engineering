using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int allPeople = int.Parse(Console.ReadLine());
            double powerOfOnePerson = double.Parse(Console.ReadLine());
            double illidansHealth = double.Parse(Console.ReadLine());

            double powerOfAllPeople = powerOfOnePerson * allPeople;

            if (powerOfAllPeople >= illidansHealth)
            {
                Console.WriteLine($"Illidan has been slain! You defeated him with {powerOfAllPeople-illidansHealth} points.");
            }
            else
            {
                Console.WriteLine($"You are not prepared! You need {illidansHealth-powerOfAllPeople} more points.");
            }
        }
    }
}
