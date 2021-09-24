using System;

namespace _01._OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();
            string input = Console.ReadLine();
            int counter = 0;
            while (input != "No More Books")
            {
                if(input == favBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                counter++;
                input = Console.ReadLine();
            }
            if(input == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
            
        }
    }
}
