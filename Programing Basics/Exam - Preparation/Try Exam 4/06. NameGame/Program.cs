using System;

namespace _06._NameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double lastResult = 0;
            string lastName = "";

            while (name != "Stop")
            {
                double result = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number == name[i])
                    {
                        result = result + 10;
                    }
                    else
                    {
                        result = result + 2;
                    }
                }
                if (result >= lastResult)
                {
                    lastName = name;
                    lastResult = result;
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"The winner is {lastName} with {lastResult} points!");
        }
    }
}
