using System;

namespace _01._ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());

            double bitcoinsEU = (bitcoins * 1168) / 1.95;

            double yuansEU = (((yuans * 0.15) * 1.76) / 1.95);

            double finalSum = (bitcoinsEU + yuansEU) * (1.00 -(comission / 100));

            Console.WriteLine($"{finalSum:f2}");
        }
    }
}
