using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CollectionFullImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            ListyIterator<string> list = new ListyIterator<string>(elements);

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        {
                            Console.WriteLine(list.Move());
                            break;
                        }
                    case "HasNext":
                        {
                            Console.WriteLine(list.HasNext());
                            break;
                        }
                    case "Print":
                        {
                            try
                            {
                                list.Print();
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case "PrintAll":
                        {
                            Console.WriteLine(string.Join(" ", list));
                            break;
                        }
                }
                command = Console.ReadLine();
            }
        }
    }
}
