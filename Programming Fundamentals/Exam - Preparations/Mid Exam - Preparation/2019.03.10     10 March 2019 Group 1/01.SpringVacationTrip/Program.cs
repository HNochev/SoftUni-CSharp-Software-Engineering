using System;

namespace _01.SpringVacationTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int countPeople = int.Parse(Console.ReadLine());
            double priceFuelKM = double.Parse(Console.ReadLine());
            double foodExpensePersonForDay = double.Parse(Console.ReadLine());
            double priceNightPerPerson = double.Parse(Console.ReadLine());

            if (countPeople > 10)
            {
                priceNightPerPerson = priceNightPerPerson * 0.75;
            }
            double expenses = 0;
            double foodAllDays = foodExpensePersonForDay * days * countPeople;
            double hotelAllDays = priceNightPerPerson * days * countPeople;
            double fuelExpenses = 0;

            expenses = foodAllDays + hotelAllDays;

            for (int i = 1; i <= days; i++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());
                fuelExpenses = (travelledDistance * priceFuelKM);

                expenses = expenses + fuelExpenses;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    expenses = expenses * 1.40;
                }

                if (i % 7 == 0)
                {
                    expenses = expenses - (expenses / countPeople);
                }

                if (budget < expenses)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {expenses - budget:f2}$ more.");
                    return;
                }

            }

                Console.WriteLine($"You have reached the destination. You have {(budget - expenses):f2}$ budget left.");

        }
    }
}
