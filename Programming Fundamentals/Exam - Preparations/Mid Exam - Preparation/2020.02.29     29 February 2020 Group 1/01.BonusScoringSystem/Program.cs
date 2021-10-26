using System;
using System.Numerics;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal countStudents = decimal.Parse(Console.ReadLine());
            decimal countLectures = decimal.Parse(Console.ReadLine());
            decimal initialBonus = decimal.Parse(Console.ReadLine());
            decimal maxBonus = 0;
            decimal maxAttendance = 0;


            for (byte i = 0; i < countStudents; i++)
            {
                decimal attendace = decimal.Parse(Console.ReadLine());
                decimal totalBonus = totalBonus = (attendace / countLectures * (5.00M + initialBonus));
                if (maxBonus < totalBonus)
                {
                    maxBonus = totalBonus;
                    maxAttendance = attendace;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");
        }
    }
}
