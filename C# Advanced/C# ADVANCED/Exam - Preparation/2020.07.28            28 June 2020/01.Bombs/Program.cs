using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effect = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Stack<int> casing = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int bombPouch = 0;

            int datura = 0;
            int cherry = 0;
            int smoke = 0;

            while (effect.Count != 0 && casing.Count != 0)
            {
                if (datura >= 3 && cherry >= 3 && smoke >= 3)
                {
                    Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
                    break;
                }

                int eff = effect.Peek();
                int cas = casing.Peek();

                int sum = eff + cas;

                if (sum == 40)
                {
                    datura++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (sum == 60)
                {
                    cherry++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (sum == 120)
                {
                    smoke++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else
                {
                    cas = casing.Pop();
                    cas = cas - 5;
                    casing.Push(cas);
                }
            }
            if (datura < 3 || cherry < 3 || smoke < 3)
            {
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            }

            if (effect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effect)}");
            }

            if (casing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");
        }
    }
}
