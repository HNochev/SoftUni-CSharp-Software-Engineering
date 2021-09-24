using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int wholeCake = a * b;
            string input = Console.ReadLine();
            int finalPieces = 0;

            while (input != "STOP")
            {
                int pieces = int.Parse(input);
                finalPieces = finalPieces + pieces;
                if (finalPieces >= wholeCake)
                {
                    Console.WriteLine($"No more cake left! You need {finalPieces - wholeCake} pieces more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if (input == "STOP")
            {
                Console.WriteLine($"{wholeCake - finalPieces} pieces are left.");
            }
        }
    }
}
