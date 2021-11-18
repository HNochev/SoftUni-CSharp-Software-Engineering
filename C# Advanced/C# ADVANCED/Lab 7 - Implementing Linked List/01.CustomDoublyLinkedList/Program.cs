using System;

namespace _01.CustomDoublyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddFirst(3);
            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(5);
            doublyLinkedList.AddLast(6);

            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            doublyLinkedList.RemoveFirst();
            doublyLinkedList.RemoveFirst();

            Console.WriteLine();
            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            doublyLinkedList.RemoveLast();

            Console.WriteLine();
            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            int[] array = doublyLinkedList.ToArray();
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
