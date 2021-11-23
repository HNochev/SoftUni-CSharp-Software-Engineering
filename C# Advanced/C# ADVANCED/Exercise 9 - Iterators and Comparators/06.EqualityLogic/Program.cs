using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfSortedPeople = new SortedSet<Person>();
            var listOfHashedPeople = new HashSet<Person>();
            var countPeople = int.Parse(Console.ReadLine());
            for (var i = 0; i < countPeople; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name, age);
                listOfHashedPeople.Add(person);
                listOfSortedPeople.Add(person);
            }

            Console.WriteLine(listOfHashedPeople.Count);
            Console.WriteLine(listOfSortedPeople.Count);
        }
    }
}
