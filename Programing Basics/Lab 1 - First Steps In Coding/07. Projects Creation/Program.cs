using System;

namespace _07._Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int countProjects = int.Parse(Console.ReadLine());
            int durationOfProjects = countProjects * 3;

            Console.WriteLine($"The architect {name} will need {durationOfProjects} hours to complete {countProjects} project/s.");
        }
    }
}
