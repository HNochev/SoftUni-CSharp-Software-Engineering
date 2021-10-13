using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                int number = int.Parse(input);
                if (number < 0)
                {
                    continue;
                }
                Console.WriteLine(CheckPalindrome(input).ToString().ToLower());
                input = Console.ReadLine();
            }
        }
        static bool CheckPalindrome(string num)
        {
            int lenght = num.Length - 1;
            int a = 0;
            while (true)
            {
                if (a > lenght)
                {
                    return true;
                }
                if (num[a] != num[lenght])
                {
                    return false;
                }
                a++;
                lenght--;
            }
        }
    }
}
