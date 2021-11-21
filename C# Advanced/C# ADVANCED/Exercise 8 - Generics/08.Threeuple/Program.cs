using System;
using System.Linq;

namespace _08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = $"{inputOne[0]} {inputOne[1]}";
            string address = inputOne[2];
            string[] townElements = inputOne.Skip(3).ToArray();
            string town = string.Join(" ", townElements);

            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(fullName, address, town);

            string[] inputTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string drunkOrNot = inputTwo[2] == "drunk" ? "True" : "False";

            Threeuple<string, int, string> secondThreeuple = new Threeuple<string, int, string>(inputTwo[0], int.Parse(inputTwo[1]), drunkOrNot);

            string[] inputThree = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(inputThree[0], double.Parse(inputThree[1]), inputThree[2]);


            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);

        }
    }
}
