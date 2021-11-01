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
                            int numberOfLetters = int.Parse(command[1]);

                            string substr = message.Substring(0, numberOfLetters);
                            message = message.Substring(numberOfLetters, message.Length - numberOfLetters) + substr;

                            break;
                        }
                    case "Insert":
                        {
                            int index = int.Parse(command[1]);
                            string str = command[2];

                            message = message.Insert(index, str);

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
