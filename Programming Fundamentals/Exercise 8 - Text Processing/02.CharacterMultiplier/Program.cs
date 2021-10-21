using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string first = str[0];
            string second = str[1];

            int sum = 0;

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                sum = sum + (first[i] * second[i]);
            }
            if (first.Length > second.Length)
            {
                for (int i = second.Length; i < first.Length; i++)
                {
                    sum = sum + first[i];
                }
            }
            else
            {
                for (int i = first.Length; i < second.Length; i++)
                {
                    sum = sum + second[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
