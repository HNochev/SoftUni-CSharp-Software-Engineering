using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = true;
            int value = int.Parse(isTrue);
            Console.WriteLine(value);
        }
        public static void printText(string text)
        {
            Console.WriteLine("I love" + text);
        }
    }
}
