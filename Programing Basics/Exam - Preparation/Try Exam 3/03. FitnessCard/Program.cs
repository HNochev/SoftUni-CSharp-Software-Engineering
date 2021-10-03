using System;

namespace _03._FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double ourSum = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            double monthPrice = 0;

            switch (gender)
            {
                case "m":
                    {
                        switch (sport)
                        {
                            case "Gym":
                                {
                                    monthPrice = 42;
                                    break;
                                }
                            case "Boxing":
                                {
                                    monthPrice = 41;
                                    break;
                                }
                            case "Yoga":
                                {
                                    monthPrice = 45;
                                    break;
                                }
                            case "Zumba":
                                {
                                    monthPrice = 34;
                                    break;
                                }
                            case "Dances":
                                {
                                    monthPrice = 51;
                                    break;
                                }
                            case "Pilates":
                                {
                                    monthPrice = 39;
                                    break;
                                }
                        }
                        break;
                    }
                case "f":
                    {
                        switch (sport)
                        {
                            case "Gym":
                                {
                                    monthPrice = 35;
                                    break;
                                }
                            case "Boxing":
                                {
                                    monthPrice = 37;
                                    break;
                                }
                            case "Yoga":
                                {
                                    monthPrice = 42;
                                    break;
                                }
                            case "Zumba":
                                {
                                    monthPrice = 31;
                                    break;
                                }
                            case "Dances":
                                {
                                    monthPrice = 53;
                                    break;
                                }
                            case "Pilates":
                                {
                                    monthPrice = 37;
                                    break;
                                }
                        }
                        break;
                    }
            }
            if(age<=19)
            {
                monthPrice = monthPrice * 0.80;
            }

            if(ourSum >= monthPrice)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${monthPrice-ourSum:f2} more.");
            }

        }
    }
}
