using System;

namespace _04.CenturiesToMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            uint centuries = uint.Parse(Console.ReadLine());
            ulong years = centuries * 100;
            decimal days = years * 365.2422M;
            decimal hours = Math.Floor(days) * 24.0M;
            decimal minutes = hours * 60.0M;

            Console.WriteLine($"{centuries} centuries = {years} years = {Math.Floor(days)} days = {hours:f0} hours = {minutes:f0} minutes");
        }
    }
}
