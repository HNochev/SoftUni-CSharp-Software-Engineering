using System;
using System.Runtime.ConstrainedExecution;

namespace _06._Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int leftFoodInKG = int.Parse(Console.ReadLine());
            double dayFoodForDog = double.Parse(Console.ReadLine());
            double dayFoodForCat = double.Parse(Console.ReadLine());
            double dayFoodForTurtle = double.Parse(Console.ReadLine());

            dayFoodForTurtle = dayFoodForTurtle / 1000;

            double neededFood = (dayFoodForDog + dayFoodForCat + dayFoodForTurtle) * days;

            if(leftFoodInKG >= neededFood)
            {
                Console.WriteLine($"{Math.Floor(leftFoodInKG - neededFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(neededFood - leftFoodInKG)} more kilos of food are needed.");
            }
        }
    }
}
