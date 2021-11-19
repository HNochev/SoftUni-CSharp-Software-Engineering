using System;

namespace _01.CustomList
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);

            list.RemoveAt(9);

            list.InsertAt(0, 20);
            list.Swap(1, 8);

            list.ForEach(x => Console.WriteLine(x));
        }
    }
}
