using System;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] nameAge = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people[i] = new Person();
                people[i].Name = nameAge[0];
                people[i].Age = int.Parse(nameAge[1]);
            }

            string filter = Console.ReadLine();
            int neededAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> ageCondition = GetCondition(filter, neededAge);
            Func<Person, string> formatter = GetFormat(format);


            Printer(people, ageCondition, formatter);

        }
        static Func<Person, string> GetFormat(string format)
        {
            switch (format)
            {
                case "name":
                    {
                        return x => $"{x.Name}";
                    }
                case "age":
                    {
                        return x => $"{x.Age}";
                    }
                case "name age":
                    {
                        return x => $"{x.Name} - {x.Age}";
                    }
                default:
                    return null;
            }
        }
        static Func<Person, bool> GetCondition(string filter, int neededAge)
        {
            switch (filter)
            {
                case "younger":
                    {
                        return x => x.Age < neededAge;
                    }
                case "older":
                    {
                        return x => x.Age >= neededAge;
                    }
                default:
                    return null;
            }
        }
        static void Printer(Person[] people, Func<Person, bool> ageCondition, Func<Person, string> format)
        {
            foreach (var person in people)
            {
                if (ageCondition(person))
                {
                    Console.WriteLine(format(person));
                }
            }
        }
    }
}
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

}

