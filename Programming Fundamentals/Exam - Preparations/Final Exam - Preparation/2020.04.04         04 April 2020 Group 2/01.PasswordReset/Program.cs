using System;
using System.Linq;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string rawPass = string.Empty;
            while (input[0] != "Done")
            {
                switch (input[0])
                {
                    case "TakeOdd":
                        {
                            for (int i = 0; i < pass.Length; i++)
                            {
                                if (i % 2 == 1)
                                {
                                    rawPass = rawPass + pass[i];
                                }
                            }
                            Console.WriteLine(rawPass);
                            pass = rawPass;
                            break;
                        }
                    case "Cut":
                        {
                            pass = pass.Remove(int.Parse(input[1]), int.Parse(input[2]));
                            Console.WriteLine(pass);
                            break;
                        }
                    case "Substitute":
                        {
                            if(pass.Contains(input[1]))
                            {
                                pass = pass.Replace(input[1], input[2]);
                                Console.WriteLine(pass);
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

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your password is: {pass}");
        }
    }
}
