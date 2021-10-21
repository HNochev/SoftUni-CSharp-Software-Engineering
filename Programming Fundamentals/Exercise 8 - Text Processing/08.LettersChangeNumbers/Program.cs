using System;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double sum = 0;

            foreach (var word in numbers)
            {
                string temp = word;
                temp = temp.Remove(0, 1);
                temp = temp.Remove(temp.Length - 1);
                double number = double.Parse(temp);

                if (Char.IsUpper(word[0]))
                {
                    number = number / (word[0] - 64);
                }
                else if (Char.IsLower(word[0]))
                {
                    number = number * (word[0] - 96);
                }

                if (Char.IsUpper(word[word.Length - 1]))
                {
                    number = number - (word[word.Length - 1] - 64);
                }
                else if (Char.IsLower(word[word.Length - 1]))
                {
                    number = number + (word[word.Length - 1] - 96);
                }

                sum = sum + number;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
