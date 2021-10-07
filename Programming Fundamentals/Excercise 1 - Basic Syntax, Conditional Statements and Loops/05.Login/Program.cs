using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string realPassword = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                realPassword = realPassword + username[i];
            }

            string input = Console.ReadLine();
            int counter = 0;
            while (input!=realPassword)
            {
                counter++;
                if(counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                if(input!=realPassword)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"User {username} logged in.");
        }
    }
}
