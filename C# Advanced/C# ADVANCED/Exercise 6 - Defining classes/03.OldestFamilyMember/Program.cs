using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] nameAge = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                family.AddMember(new Person(nameAge[0], int.Parse(nameAge[1])));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
