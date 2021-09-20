using System;

namespace _9._Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string normalOrLeapYear = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsInTown = int.Parse(Console.ReadLine());

            int weekendsInSofia = 48 - weekendsInTown;
            double gamesInSofia = weekendsInSofia * 3.00 / 4.00 ;

            double gamesInHolidays = holidays * 2.00 / 3.00;

            double finalGames = gamesInSofia + gamesInHolidays + weekendsInTown;

            if(normalOrLeapYear == "leap")
            {
                finalGames = finalGames * 1.15;
            }

            Console.WriteLine(Math.Floor(finalGames));
        }
    }
}
