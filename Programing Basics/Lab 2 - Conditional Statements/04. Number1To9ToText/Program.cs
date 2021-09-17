using System;

namespace _04._Number1To9ToText
{
    class Program
    {
        static void Main(string[] args)
        {
            int oneToNine = int.Parse(Console.ReadLine());

            if(oneToNine == 1)
            {
                Console.WriteLine("one");
            }
            else if(oneToNine == 2)
            {
                Console.WriteLine("two");
            }
            else if (oneToNine == 3)
            {
                Console.WriteLine("three");
            }
            else if (oneToNine == 4)
            {
                Console.WriteLine("four");
            }
            else if (oneToNine == 5)
            {
                Console.WriteLine("five");
            }
            else if (oneToNine == 6)
            {
                Console.WriteLine("six");
            }
            else if (oneToNine == 7)
            {
                Console.WriteLine("seven");
            }
            else if (oneToNine == 8)
            {
                Console.WriteLine("eight");
            }
            else if (oneToNine == 9)
            {
                Console.WriteLine("nine");
            }
            else
            {
                Console.WriteLine("number too big");
            }
        }
    }
}
