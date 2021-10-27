using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            uint energy = uint.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            byte wins = 0;

            while (input != "End of battle")
            {
                uint distance = uint.Parse(input);
                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    break;
                }
                energy = energy - distance;
                wins++;
                if (wins % 3 == 0)
                {
                    energy = energy + wins;
                }

                input = Console.ReadLine();
            }
            if(input == "End of battle")
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
