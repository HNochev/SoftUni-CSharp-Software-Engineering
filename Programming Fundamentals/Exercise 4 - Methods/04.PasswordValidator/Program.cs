using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (!CheckChars(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!CheckForOnlyLettersAndDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!CheckLenght(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (CheckChars(password) && CheckForOnlyLettersAndDigits(password) && CheckLenght(password))
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool CheckChars(string pass)
        {
            if (!(pass.Length > 5 && pass.Length < 11))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool CheckForOnlyLettersAndDigits(string pass)
        {
            if (pass.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < pass.Length; i++)
            {
                if (!((pass[i] >= 'a' && pass[i] <= 'z') || (pass[i] >= 'A' && pass[i] <= 'Z') || (pass[i] >= '0' && pass[i] <= '9')))
                {
                    return false;
                }
            }
            return true; ;
        }
        static bool CheckLenght(string pass)
        {
            int digits = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= '0' && pass[i] <= '9')
                {
                    digits++;
                }
            }
            if (digits < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
