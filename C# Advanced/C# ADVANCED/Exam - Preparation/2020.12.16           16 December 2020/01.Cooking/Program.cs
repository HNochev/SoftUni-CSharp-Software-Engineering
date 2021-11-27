using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(firstInput);
            Stack<int> ingredients = new Stack<int>(secondInput);

            int breads = 0;
            int cakes = 0;
            int pastries = 0;
            int pies = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sum = liquids.Dequeue() + ingredients.Peek();
                if (sum == 25)
                {
                    breads++;
                    ingredients.Pop();
                }
                else if (sum == 50)
                {
                    cakes++;
                    ingredients.Pop();
                }
                else if (sum == 75)
                {
                    pastries++;
                    ingredients.Pop();
                }
                else if (sum == 100)
                {
                    pies++;
                    ingredients.Pop();
                }
                else
                {
                    int ingredient = ingredients.Pop() + 3;
                    ingredients.Push(ingredient);
                }
            }

            if (breads > 0 && cakes > 0 && pastries > 0 && pies > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }

            Console.WriteLine($"Bread: {breads}");
            Console.WriteLine($"Cake: {cakes}");
            Console.WriteLine($"Fruit Pie: {pies}");
            Console.WriteLine($"Pastry: {pastries}");
        }
    }
}
