using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            byte worker1 = byte.Parse(Console.ReadLine());
            byte worker2 = byte.Parse(Console.ReadLine());
            byte worker3 = byte.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int workersStudentsPerHour = worker1 + worker2 + worker3;
            int hours = 0;

            while(studentsCount != 0)
            {
                if (hours % 4 == 0 && hours != 0)
                {
                    hours++;
                    continue;
                }
                hours++;
                studentsCount = studentsCount - workersStudentsPerHour;
                if(studentsCount < 0)
                {
                    studentsCount = 0;
                }
            }
            if (hours % 4 == 0 && hours != 0)
            {
                hours++;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
