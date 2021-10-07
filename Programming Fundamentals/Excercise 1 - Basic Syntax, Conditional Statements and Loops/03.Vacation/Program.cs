using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            switch (groupType)
            {
                case "Students":
                    {
                        switch (day)
                        {
                            case "Friday":
                                {
                                    price = 8.45;
                                    break;
                                }
                            case "Saturday":
                                {
                                    price = 9.80;
                                    break;
                                }
                            case "Sunday":
                                {
                                    price = 10.46;
                                    break;
                                }
                        }
                        if(numberOfPeople >= 30)
                        {
                            price = price * 0.85;
                        }
                        break;
                    }
                case "Business":
                    {
                        switch (day)
                        {
                            case "Friday":
                                {
                                    price = 10.90;
                                    break;
                                }
                            case "Saturday":
                                {
                                    price = 15.60;
                                    break;
                                }
                            case "Sunday":
                                {
                                    price = 16.00;
                                    break;
                                }
                        }
                        if(numberOfPeople >= 100)
                        {
                            numberOfPeople = numberOfPeople - 10;
                        }
                        break;
                    }
                case "Regular":
                    {
                        switch (day)
                        {
                            case "Friday":
                                {
                                    price = 15.00;
                                    break;
                                }
                            case "Saturday":
                                {
                                    price = 20.00;
                                    break;
                                }
                            case "Sunday":
                                {
                                    price = 22.50;
                                    break;
                                }
                        }
                        if(numberOfPeople >= 10 && numberOfPeople <=20)
                        {
                            price = price * 0.95;
                        }
                        break;
                    }
            }
            double fullPrice = numberOfPeople * price;
            Console.WriteLine($"Total price: {fullPrice:f2}");
        }
    }
}
