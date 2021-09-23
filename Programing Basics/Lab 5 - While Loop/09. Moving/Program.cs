using System;

namespace _09._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double takenSpace = 0;
            double finalSpace = 0;

            while(input != "Done")
            {
                int boxes = int.Parse(input);
                double apartmentSize = width * lenght * height;
                takenSpace = takenSpace + boxes;
                finalSpace = apartmentSize - takenSpace;
                if(finalSpace < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(finalSpace)} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }
            if(input == "Done")
            {
                Console.WriteLine($"{finalSpace} Cubic meters left.");
            }
        }
    }
}
