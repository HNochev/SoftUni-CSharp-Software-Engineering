using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTickets = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());

            double finalPrice = priceTicket * countTickets;

            if(finalPrice > budget)
            {
                Console.WriteLine($"The budget of {budget}$ is not enough. Your client can't buy {countTickets} tickets with this budget!");
            }
            else
            {
                Console.WriteLine($"You can sell your client {countTickets} tickets for the price of {finalPrice}$!");
                Console.WriteLine($"Your client should become a change of {budget-finalPrice}$!");
            }
        }
    }
}
