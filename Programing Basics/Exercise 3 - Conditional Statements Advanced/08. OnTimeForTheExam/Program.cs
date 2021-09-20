using System;

namespace _08._OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArrive = int.Parse(Console.ReadLine());
            int minuteArrive = int.Parse(Console.ReadLine());

            int fullMinutesExam = hourExam * 60 + minuteExam;
            int fullMinutesArrive = hourArrive * 60 + minuteArrive;
            int minuteDifference = fullMinutesExam - fullMinutesArrive;
            
            if(minuteDifference >= 0 && minuteDifference <= 59)
            {
                if(minuteDifference <= 30)
                {
                    Console.WriteLine("On time");
                }
                else
                {
                    Console.WriteLine("Early");
                }
                Console.WriteLine($"{minuteDifference} minutes before the start");
            }
            else if (minuteDifference >= 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{minuteDifference / 60}:{(minuteDifference % 60):d2} hours before the start");
            }
            else if (minuteDifference >= - 59)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{Math.Abs(minuteDifference)} minutes after the start");
            }
            else if (minuteDifference <= -60)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{Math.Abs(minuteDifference/60)}:{Math.Abs(minuteDifference % 60):d2} hours after the start");
            }
        }
    }
}
