using System;

namespace _04._TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double musala = 0;
            double monblan = 0;
            double kilimadjaro = 0;
            double k2 = 0;
            double everest = 0;
            double allPeople = 0;

            for (int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                if (people <= 5)
                {
                    musala = musala + people;
                }
                else if (people > 5 && people <= 12)
                {
                    monblan = monblan + people;
                }
                else if (people > 12 && people <= 25)
                {
                    kilimadjaro = kilimadjaro + people;
                }
                else if (people > 25 && people <= 40)
                {
                    k2 = k2 + people;
                }
                else if (people > 40)
                {
                    everest = everest + people;
                }
                allPeople = allPeople + people;
            }
            Console.WriteLine($"{musala/allPeople*100:f2}%");
            Console.WriteLine($"{monblan/allPeople*100:f2}%");
            Console.WriteLine($"{kilimadjaro/allPeople*100:f2}%");
            Console.WriteLine($"{k2/allPeople*100:f2}%");
            Console.WriteLine($"{everest/allPeople*100:f2}%");
        }
    }
}
