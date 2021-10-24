using System;

namespace _01.TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysAdventure = int.Parse(Console.ReadLine());
            int countPlayers = int.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double waterDayOnePerson = double.Parse(Console.ReadLine());
            double foodDayOnePerson = double.Parse(Console.ReadLine());

            double totalWater = daysAdventure * countPlayers * waterDayOnePerson;
            double totalFood = daysAdventure * countPlayers * foodDayOnePerson;


            for (int i = 1; i <= daysAdventure; i++)
            {

                double energyLoss = double.Parse(Console.ReadLine());

                groupsEnergy = groupsEnergy - energyLoss;

                if (groupsEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    break;
                }
                if (i % 2 == 0)
                {
                    groupsEnergy = groupsEnergy * 1.05;
                    totalWater = totalWater * 0.70;
                }
                if (i % 3 == 0)
                {
                    groupsEnergy = groupsEnergy * 1.10;
                    totalFood = totalFood - (totalFood / countPlayers);
                }
            }
            if (groupsEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupsEnergy:f2} energy!");
            }

        }
    }
}
