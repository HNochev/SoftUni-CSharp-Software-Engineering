using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Decode")
            {
                switch (command[0])
                {
                    case "Move":
                        {
                            string str = message.Substring(0, int.Parse(command[1]));
                            message = message.Remove(0, int.Parse(command[1]));
                            message = message + str;
                            break;
                        }
                    case "Insert":
                        {
                            message = message.Insert(int.Parse(command[1]), command[2]);
                            break;
                        }
                    case "ChangeAll":
                        {
                            message = message.Replace(command[1], command[2]);
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
