using System;

namespace _04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            double pagesForHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double timeForTheBook = pages / pagesForHour;
            double hoursADay = timeForTheBook / days;

            Console.WriteLine(hoursADay);
        }
    }
}
