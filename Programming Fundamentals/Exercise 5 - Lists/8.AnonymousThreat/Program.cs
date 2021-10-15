using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    string concatData = string.Empty;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > list.Count - 1)
                    {
                        endIndex = list.Count - 1;
                    }
                    if (startIndex < list.Count - 1)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            concatData = concatData + list[i];
                        }

                        list.RemoveRange(startIndex, endIndex - startIndex + 1);
                        list.Insert(startIndex, concatData);
                    }

                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partition = int.Parse(command[2]);

                    string part = list[index];
                    List<string> devidedWords = new List<string>();

                    int alphabetsInPartly = part.Length / partition;

                    int startIndex = 0;

                    for (int i = 0; i < partition; i++)
                    {
                        if (i == partition - 1)
                        {
                            devidedWords.Add(part.Substring(startIndex, part.Length - startIndex));
                        }
                        else
                        {
                            devidedWords.Add(part.Substring(startIndex, alphabetsInPartly));
                            startIndex = startIndex + alphabetsInPartly;
                        }
                    }

                    list.RemoveAt(index);
                    list.InsertRange(index, devidedWords);

                }


                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine(string.Join(' ', list));
        }
    }
}
