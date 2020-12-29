using System;

namespace _07.CustomLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList<int>();
            linkedList.AddFirst(5);
            linkedList.AddLast(10);
            linkedList.AddFirst(20);
            linkedList.AddLast(22);
            linkedList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(linkedList.RemoveFirst());
            Console.WriteLine(linkedList.RemoveLast());

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
