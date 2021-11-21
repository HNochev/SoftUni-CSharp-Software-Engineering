using System;

namespace _09.CustomLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.AddFirst("a");
            doublyLinkedList.AddFirst("b");
            doublyLinkedList.AddFirst("c");
            doublyLinkedList.AddLast("d");
            doublyLinkedList.AddLast("e");
            doublyLinkedList.AddLast("f");

            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            doublyLinkedList.RemoveFirst();
            doublyLinkedList.RemoveFirst();

            Console.WriteLine();
            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            doublyLinkedList.RemoveLast();

            Console.WriteLine();
            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            string[] array = doublyLinkedList.ToArray();
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
