using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Xml;

namespace _3.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] name = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if(name[2] == "going!")
                {
                    if (names.Contains(name[0]))
                    {
                        Console.WriteLine($"{name[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(name[0]);
                    }
                }
                else if (name[2] == "not")
                {
                    if(names.Contains(name[0]))
                    {
                        names.Remove(name[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{name[0]} is not in the list!");
                    }
                }
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
