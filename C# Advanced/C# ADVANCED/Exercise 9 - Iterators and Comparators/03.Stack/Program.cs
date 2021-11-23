using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> elements = new CustomStack<int>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandData = command
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                switch (commandData[0])
                {
                    case "Push":
                        {
                            for (int i = 1; i < commandData.Length; i++)
                            {
                                int item = int.Parse(commandData[i]);
                                elements.Push(item);
                            }
                            break;
                        }
                    case "Pop":
                        {
                            try
                            {
                                elements.Pop();
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                }
                command = Console.ReadLine();
            }

            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
        }
    }
}
