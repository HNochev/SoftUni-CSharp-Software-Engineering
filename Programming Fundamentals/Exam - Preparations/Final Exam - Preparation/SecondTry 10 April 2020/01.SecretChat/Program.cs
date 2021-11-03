using System;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            while(command[0] != "Reveal")
            {
                switch (command[0])
                {
                    case "InsertSpace":
                        {
                            message = message.Insert(int.Parse(command[1]), " ");
                            Console.WriteLine(message);
                            break;
                        }
                    case "Reverse":
                        {
                            string substr = command[1];
                            if(message.Contains(substr))
                            {
                                message = message.Remove(message.IndexOf(substr),substr.Length);

                                substr = new string(substr.Reverse().ToArray());
                                message = message + substr;
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
                            message = message.Replace(command[1], command[2]);
                            Console.WriteLine(message);
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
