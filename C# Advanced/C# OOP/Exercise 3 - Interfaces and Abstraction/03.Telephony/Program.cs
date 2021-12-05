using System;
using System.Linq;

namespace _03.Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            SmartPhone smartPhone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string number in numbers)
            {
                try
                {
                    string result = number.Length == 10
                        ? smartPhone.Call(number)
                        : stationaryPhone.Call(number);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    string result = smartPhone.Browse(url);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
