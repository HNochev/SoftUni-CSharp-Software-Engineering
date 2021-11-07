using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int currGunBarrel = sizeOfGunBarrel;
            int countOfBullets = 0;
            int finalPrice = 0;
            int[] bulletsArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locksArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int inteligence = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsArray);
            Queue<int> locks = new Queue<int>(locksArray);

            while(locks.Count > 0 || bullets.Count > 0)
            {
                int currLock = locks.Peek();
                int currBullet = bullets.Pop();
                countOfBullets++;
                currGunBarrel--;
                if(currLock >= currBullet)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (currGunBarrel == 0 && bullets.Any())
                {
                    currGunBarrel = sizeOfGunBarrel;
                    Console.WriteLine("Reloading!");
                }
                if(!locks.Any())
                {
                    break;
                }
                if(!bullets.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
            }
            finalPrice = countOfBullets * bulletPrice;
            inteligence = inteligence - finalPrice;
            if(locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligence}");
            }
        }
    }
}
