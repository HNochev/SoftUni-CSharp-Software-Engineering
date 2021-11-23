using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] personData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Person person = new Person(personData[0], int.Parse(personData[1]), personData[2]);

                people.Add(person);

                input = Console.ReadLine();
            }

            int indexOfPersonToCompare = int.Parse(Console.ReadLine());
            if (indexOfPersonToCompare < people.Count)
            {
                Person personToCompare = people[indexOfPersonToCompare];
                people.RemoveAt(indexOfPersonToCompare);

                int countMatches = 1;
                int countNotEqualPeople = 0;
                int totalPeople = people.Count + 1;

                for (int i = 0; i < people.Count; i++)
                {
                    int compare = personToCompare.CompareTo(people[i]);

                    if (compare == 0)
                    {
                        countMatches++;
                    }
                    else
                    {
                        countNotEqualPeople++;
                    }
                }

                Console.WriteLine($"{countMatches} {countNotEqualPeople} {totalPeople}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
