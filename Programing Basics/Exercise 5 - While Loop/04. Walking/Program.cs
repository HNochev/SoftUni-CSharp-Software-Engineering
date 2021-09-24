using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int steps = 0;
            while(steps <= 10000)
            {
                if(input == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    steps = steps + stepsToHome;
                    if(steps > 10000)
                    {
                        break;
                    }
                    Console.WriteLine($"{10000-steps} more steps to reach goal.");
                    break;
                }
                int number = int.Parse(input);
                steps = steps + number;
                if (steps <= 10000)
                {
                    input = Console.ReadLine();
                }
            }
            if(steps > 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");
            }
        }
    }
}
