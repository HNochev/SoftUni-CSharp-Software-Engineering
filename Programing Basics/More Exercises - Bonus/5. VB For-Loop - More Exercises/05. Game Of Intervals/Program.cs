using System;

namespace _05._Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            double zero = 0;
            double one = 0;
            double two = 0;
            double three = 0;
            double four = 0;
            double invalid = 0;
            double points = 0;

            for (int i = 0; i < steps; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if(number >=0 &&number<10)
                {
                    zero++;
                    points = points + number * 0.20;
                }
                else if(number>=10 &&number<20)
                {
                    one++;
                    points = points + number * 0.30;
                }
                else if (number >= 20 && number < 30)
                {
                    two++;
                    points = points + number * 0.40;
                }
                else if (number >= 30 && number < 40)
                {
                    three++;
                    points = points + 50;
                }
                else if (number >= 40 && number <= 50)
                {
                    four++;
                    points = points + 100;
                }
                else
                {
                    invalid++;
                    points = points/2;
                }
            }
            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {zero/steps*100:f2}%");
            Console.WriteLine($"From 10 to 19: {one/steps*100:f2}%");
            Console.WriteLine($"From 20 to 29: {two/steps*100:f2}%");
            Console.WriteLine($"From 30 to 39: {three/steps*100:f2}%");
            Console.WriteLine($"From 40 to 50: {four/steps*100:f2}%");
            Console.WriteLine($"Invalid numbers: {invalid/steps*100:f2}%");
        }
    }
}
