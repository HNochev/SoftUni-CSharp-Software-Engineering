using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];

                    identifiables.Add(new Citizen(name, age, id));
                }
                else if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];

                    identifiables.Add(new Robot(model, id));
                }
            }

            string idToEndWith = Console.ReadLine();

            foreach (var identifiable in identifiables.Where(x => x.Id.EndsWith(idToEndWith)))
            {
                Console.WriteLine(identifiable.Id);
            }
        }
    }
}
