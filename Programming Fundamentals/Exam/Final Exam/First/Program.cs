using System;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while(command[0] != "Done")
            {
                switch (command[0])
                {
                    case "Change":
                        {
                            text = text.Replace(command[1], command[2]);
                            Console.WriteLine(text);
                            break;
                        }
                    case "Includes":
                        {
                            if(text.Contains(command[1]))
                            {
                                Console.WriteLine("True");
                            }
                            else
                            {
                                Console.WriteLine("False");
                            }
                            break;
                        }
                    case "End":
                        {
                            string str = command[1];

                            if(text.EndsWith(str))
                            {
                                Console.WriteLine("True");
                            }
                            else
                            {
                                Console.WriteLine("False");
                            }
                            break;
                        }
                    case "Uppercase":
                        {
                            text = text.ToUpper();
                            Console.WriteLine(text);
                            break;
                        }
                    case "FindIndex":
                        {
                            Console.WriteLine(text.IndexOf(command[1]));
                            break;
                        }
                    case "Cut":
                        {
                            int startIndex = int.Parse(command[1]);
                            int lenght = int.Parse(command[2]);

                            text = text.Substring(startIndex, lenght);

                            Console.WriteLine(text);
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
