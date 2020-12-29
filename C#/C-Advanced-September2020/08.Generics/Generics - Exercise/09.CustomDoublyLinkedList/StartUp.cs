using System;

namespace CustomDoublyLinkedList
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

            var array = linkedList.ToArray();

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

        }
    }
}
