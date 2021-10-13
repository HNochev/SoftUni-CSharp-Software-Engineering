using System;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] text = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (text[0] == "exchange")
                {
                    if (int.Parse(text[1]) < 0 || int.Parse(text[1]) >= array.Length)
                    {
                        Console.WriteLine("Invalid index");
                        input = Console.ReadLine();
                        continue;
                    }
                    Exchange(array, int.Parse(text[1]));
                }
                else if (text[0] == "max")
                {
                    if (text[1] == "even")
                    {
                        MaxEven(array);
                    }
                    else if (text[1] == "odd")
                    {
                        MaxOdd(array);
                    }
                }
                else if (text[0] == "min")
                {
                    if (text[1] == "even")
                    {
                        MinEven(array);
                    }
                    else if (text[1] == "odd")
                    {
                        MinOdd(array);
                    }
                }
                else if (text[0] == "first")
                {
                    if (text[2] == "even")
                    {
                        FirstEven(array, text);
                    }
                    else if (text[2] == "odd")
                    {
                        FirstOdd(array, text);
                    }
                }
                else if (text[0] == "last")
                {
                    if (text[2] == "even")
                    {
                        LastEven(array, text);
                    }
                    else if (text[2] == "odd")
                    {
                        LastOdd(array, text);
                    }
                }
                input = Console.ReadLine();
            }
            if (input == "end")
            {
                Console.WriteLine($"[{string.Join(", ", array)}]");
            }
        }
        static void Exchange(int[] arr, int index)
        {
            int[] firstArray = new int[arr.Length - index - 1];
            int[] secondArray = new int[index + 1];

            int firstArreyCounter = 0;

            for (int i = index + 1; i < arr.Length; i++)
            {
                firstArray[firstArreyCounter] = arr[i];
                firstArreyCounter++;
            }
            for (int i = 0; i < secondArray.Length; i++)
            {
                secondArray[i] = arr[i];
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                arr[i] = firstArray[i];
            }
            for (int i = 0; i < secondArray.Length; i++)
            {
                arr[firstArray.Length + i] = secondArray[i];
            }
        }
        static void MaxEven(int[] arr)
        {
            int maxEvenNumIndex = int.MinValue;
            int maxEvenNumber = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] >= maxEvenNumber)
                    {
                        maxEvenNumIndex = i;
                        maxEvenNumber = arr[i];
                    }
                }
            }
            if (maxEvenNumIndex == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxEvenNumIndex);
            }
        }
        static void MaxOdd(int[] arr)
        {
            int maxOddNumIndex = int.MinValue;
            int maxOddNumber = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    if (arr[i] >= maxOddNumber)
                    {
                        maxOddNumIndex = i;
                        maxOddNumber = arr[i];
                    }
                }
            }
            if (maxOddNumIndex == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxOddNumIndex);
            }
        }
        static void MinEven(int[] arr)
        {
            int minEvenNumIndex = int.MaxValue;
            int minEvenNumber = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] <= minEvenNumber)
                    {
                        minEvenNumIndex = i;
                        minEvenNumber = arr[i];
                    }
                }
            }
            if (minEvenNumIndex == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minEvenNumIndex);
            }
        }
        static void MinOdd(int[] arr)
        {
            int minOddNumIndex = int.MaxValue;
            int minOddNumber = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    if (arr[i] <= minOddNumber)
                    {
                        minOddNumIndex = i;
                        minOddNumber = arr[i];
                    }
                }
            }
            if (minOddNumIndex == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minOddNumIndex);
            }
        }
        static void FirstEven(int[] arr, string[] text)
        {
            string numbers = string.Empty;
            int counter = 0;

            if (int.Parse(text[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        numbers = numbers + arr[i] + " ";
                        counter++;
                    }
                    if (counter == int.Parse(text[1]))
                    {
                        break;
                    }
                }

                string[] result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
        }
        static void FirstOdd(int[] arr, string[] text)
        {
            string numbers = string.Empty;
            int counter = 0;

            if (int.Parse(text[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 != 0)
                    {
                        numbers = numbers + arr[i] + " ";
                        counter++;
                    }
                    if (counter == int.Parse(text[1]))
                    {
                        break;
                    }
                }

                string[] result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
        }
        static void LastEven(int[] arr, string[] text)
        {
            string number = string.Empty;
            int counter = 0;

            if (int.Parse(text[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == 0)
                    {
                        number = number + arr[i] + " ";
                        counter++;
                    }
                    if (counter == int.Parse(text[1]))
                    {
                        break;
                    }
                }

                string[] result = number.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(result);
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
        }
        static void LastOdd(int[] arr, string[] text)
        {
            string number = string.Empty;
            int counter = 0;

            if (int.Parse(text[1]) > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 != 0)
                    {
                        number = number + arr[i] + " ";
                        counter++;
                    }
                    if (counter == int.Parse(text[1]))
                    {
                        break;
                    }
                }

                string[] result = number.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Array.Reverse(result);
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
        }
    }
}
