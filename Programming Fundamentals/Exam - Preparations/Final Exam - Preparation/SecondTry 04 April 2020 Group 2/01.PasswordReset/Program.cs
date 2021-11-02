using System;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Done")
            {
                switch (command[0])
                {
                    case "TakeOdd":
                        {
                            string odd = string.Empty;
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    odd = odd + text[i];
                                }
                            }
                            text = odd;
                            Console.WriteLine(text);
                            break;
                        }
                    case "Cut":
                        {
                            string beggining = text.Substring(0, int.Parse(command[1]));
                            string ending = text.Substring(int.Parse(command[1]) + int.Parse(command[2]));

                            text = beggining + ending;
                            Console.WriteLine(text);
                            break;
                        }
                    case "Substitute":
                        {
                            if (text.Contains(command[1]))
                            {
                                text = text.Replace(command[1], command[2]);
                                Console.WriteLine(text);
                            }
                            else
                            {
                                Console.WriteLine("Nothing to replace!");
                            }
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your password is: {text}");
        }
    }
}
