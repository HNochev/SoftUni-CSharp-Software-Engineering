using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            Stack<string> texts = new Stack<string>();
            texts.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "1":
                        {
                            sb.Append(command[1]);
                            texts.Push(sb.ToString());
                            break;
                        }
                    case "2":
                        {
                            int count = int.Parse(command[1]);
                            sb.Remove(sb.Length - count, count);
                            texts.Push(sb.ToString());
                            break;
                        }
                    case "3":
                        {
                            int index = int.Parse(command[1]) - 1;
                            Console.WriteLine(sb[index]);
                            break;
                        }
                    case "4":
                        {
                            texts.Pop();
                            sb.Clear();
                            sb.Append(texts.Peek());
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
