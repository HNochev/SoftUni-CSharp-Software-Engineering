using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "Reveal")
            {
                switch (input[0])
                {
                    case "InsertSpace":
                        {
                            message = message.Insert(int.Parse(input[1]), " ");
                            Console.WriteLine(message);
                            break;
                        }
                    case "Reverse":
                        {
                            if(message.Contains(input[1]))
                            {
                                string reversed = new string(input[1].Reverse().ToArray());
                                int index = message.IndexOf(input[1]);

                                message = message.Remove(index, input[1].Length);
                                message = message.Insert(message.Length, reversed);
                                Console.WriteLine(message);
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                            break;
                        }
                    case "ChangeAll":
                        {
                            message = message.Replace(input[1], input[2]);
                            Console.WriteLine(message);
                            break;
                        }
                }
                input = Console.ReadLine()
                .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
