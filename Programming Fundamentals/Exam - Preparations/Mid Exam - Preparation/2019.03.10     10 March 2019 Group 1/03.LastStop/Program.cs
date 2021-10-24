using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paintings = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] input = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (input[0])
                {
                    case "Change":
                        {
                            if (paintings.Contains(input[1]))
                            {
                                int index1 = paintings.IndexOf(input[1]);
                                paintings[index1] = input[2];
                            }
                            break;
                        }
                    case "Hide":
                        {
                            paintings.Remove(input[1]);
                            break;
                        }
                    case "Switch":
                        {
                            if (paintings.Contains(input[1]) && paintings.Contains(input[2]))
                            {
                                int index1 = paintings.IndexOf(input[1]);
                                int index2 = paintings.IndexOf(input[2]);

                                paintings[index1] = input[2];
                                paintings[index2] = input[1];
                            }
                            break;
                        }
                    case "Insert":
                        {
                            int index = int.Parse(input[1]);
                            if (index + 1 > 0 && index + 1 < paintings.Count)
                            {
                                paintings.Insert(index + 1, input[2]);
                            }
                            break;
                        }
                    case "Reverse":
                        {
                            paintings.Reverse();
                            break;
                        }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', paintings));
        }
    }
}
