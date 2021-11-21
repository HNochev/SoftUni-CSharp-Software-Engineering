using System;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine()
                .Split(" ");
            string fullName = $"{firstInput[0]} {firstInput[1]}";

            CustomTuple<string, string> tupleOne = new CustomTuple<string, string>(fullName, firstInput[2]);

            string[] secondInput = Console.ReadLine()
                .Split(" ");
            CustomTuple<string, int> tupleTwo = new CustomTuple<string, int>(secondInput[0], int.Parse(secondInput[1]));

            string[] thirdInput = Console.ReadLine()
                .Split(" ");
            CustomTuple<int, double> tupleThree = new CustomTuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));

            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}
