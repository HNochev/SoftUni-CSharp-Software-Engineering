using System;

namespace _07._HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double heightHouse = double.Parse(Console.ReadLine());
            double lenghtHouse = double.Parse(Console.ReadLine());
            double heightRoof = double.Parse(Console.ReadLine());

            double frontSide = (heightHouse * heightHouse) - (1.2 * 2);
            double backSide = heightHouse * heightHouse;
            double secondSides = 2*((lenghtHouse * heightHouse) - (Math.Pow(1.5, 2)));
            double fullGreenArea = frontSide + backSide + secondSides;

            double roofUpperSides = 2 * (lenghtHouse * heightHouse);
            double roofFrontBackSides = 2 * (heightHouse * heightRoof / 2);
            double fullRedArea = roofFrontBackSides + roofUpperSides;

            double finalGreen = fullGreenArea / 3.4;
            double finalRed = fullRedArea / 4.3;

            Console.WriteLine($"{finalGreen:f2}");
            Console.WriteLine($"{finalRed:f2}");
        }
    }
}
