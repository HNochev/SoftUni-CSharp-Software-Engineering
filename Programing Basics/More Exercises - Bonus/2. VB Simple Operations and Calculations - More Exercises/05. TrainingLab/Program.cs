using System;

namespace _05._TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            width = width - 1.00;
            double tablesInWidth =Math.Floor(width / 0.7);
            double tablesInLenght = Math.Floor(lenght/1.20);

            double finalWorkingPlaces = tablesInLenght * tablesInWidth - 3;

            Console.WriteLine(finalWorkingPlaces);
        }
    }
}
