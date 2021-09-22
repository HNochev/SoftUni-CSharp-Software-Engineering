using System;
using System.Net.Sockets;

namespace _06._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 1; i <= tabs; i++)
            {
                string site = Console.ReadLine();
                if (site == "Facebook")
                {
                    salary = salary - 150;
                }
                else if (site == "Instagram")
                {
                    salary = salary - 100;
                }
                else if (site == "Reddit")
                {
                    salary = salary - 50;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
