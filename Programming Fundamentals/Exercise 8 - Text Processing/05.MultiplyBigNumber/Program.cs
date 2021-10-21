using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {

        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine().TrimStart('0'); //9999
            int num = int.Parse(Console.ReadLine());              //9

            if(num == 0 || bigNumber == "")
            {
                Console.WriteLine("0");
                return;
            }

            StringBuilder sb = new StringBuilder();
            int reminder = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int result = int.Parse(bigNumber[i].ToString()) * num + reminder;

                reminder = result / 10;
                result = result % 10;

                sb.Append(result);
            }
            if(reminder != 0)
            {
                sb.Append(reminder);
            }

            Console.WriteLine(string.Join("", sb.ToString().Reverse()));
        }
    }
}

