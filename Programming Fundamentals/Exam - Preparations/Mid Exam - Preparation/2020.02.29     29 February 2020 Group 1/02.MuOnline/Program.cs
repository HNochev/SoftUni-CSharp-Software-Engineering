using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            double health = 100;
            double bitcoins = 0;

            List<string> input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                string[] command = input[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string action = command[0];
                int number = int.Parse(command[1]);

                if(action == "potion")
                {
                    health = health + number;
                    double additionalHealth = 0;
                    if(health > 100)
                    {
                        additionalHealth = health - 100;
                        health = 100;
                    }
                    Console.WriteLine($"You healed for {number-additionalHealth} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if(action == "chest")
                {
                    bitcoins = bitcoins + number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    if(health > number)
                    {
                        health = health - number;
                        Console.WriteLine($"You slayed {action}.");
                    }
                    else if(health <= number)
                    {
                        Console.WriteLine($"You died! Killed by {action}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
