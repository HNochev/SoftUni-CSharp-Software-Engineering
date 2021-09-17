using System;

namespace _06._PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            string originalPass = "s3cr3t!P@ssw0rd";

            if(pass == originalPass)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
