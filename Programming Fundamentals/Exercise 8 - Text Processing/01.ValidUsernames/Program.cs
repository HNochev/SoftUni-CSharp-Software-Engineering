using System;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] users = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            foreach (var item in users)
            {
                bool isOnlyLettersAndDigits = item.All(Char.IsLetterOrDigit) || item.Contains("-") || item.Contains("_");

                if (item.Length >= 3 && item.Length <= 16 && isOnlyLettersAndDigits)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
