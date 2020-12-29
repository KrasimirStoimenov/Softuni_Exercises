using System;

namespace CustomDataStructures
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomList myCustomList = new CustomList();
            Console.WriteLine("MyCustomList");
            Console.WriteLine(myCustomList.Count);

            myCustomList.Add(1);
            myCustomList.Add(2);
            myCustomList.Add(3);
            myCustomList.Add(4);
            myCustomList.Add(5);
            Console.WriteLine(myCustomList.RemoveAt(2));
            Console.WriteLine(myCustomList.RemoveAt(0));
            Console.WriteLine(myCustomList.RemoveAt(1));
            myCustomList.Insert(1, 4);
            myCustomList.Insert(3, 6);
            Console.WriteLine(myCustomList.Contains(6));
            Console.WriteLine(myCustomList.Contains(8));
            myCustomList.Swap(0, 2);
            Console.WriteLine(myCustomList.Count);
            Console.WriteLine(myCustomList);
            myCustomList.Reverse();
            Console.WriteLine(myCustomList);
            myCustomList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-----------------------------");

            Console.WriteLine("MyCustomStack");
            var myCustomStack = new CustomStack();

            myCustomStack.Push(1);
            myCustomStack.Push(2);
            myCustomStack.Push(3);
            myCustomStack.Push(4);
            myCustomStack.Push(5);

            myCustomStack.Pop();
            Console.WriteLine(myCustomStack.Peek());
            myCustomStack.ForEach(x => Console.WriteLine(x));
        }
    }
}
