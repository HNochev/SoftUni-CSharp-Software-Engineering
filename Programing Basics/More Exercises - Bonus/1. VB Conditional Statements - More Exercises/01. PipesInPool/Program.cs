using System;

namespace _01._PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            double P1 = int.Parse(Console.ReadLine());
            double P2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double finalVolume = (P1 + P2) * hours;

            if (volume >= finalVolume)
            {
                Console.WriteLine($"The pool is {finalVolume / volume * 100:f2}% full. Pipe 1: {(P1 * hours) / finalVolume * 100:f2}%. Pipe 2: {P2 / (P1 + P2) * 100:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {hours:f2} hours the pool overflows with {Math.Abs(volume - finalVolume):f2} liters.");
            }
        }
    }
}
