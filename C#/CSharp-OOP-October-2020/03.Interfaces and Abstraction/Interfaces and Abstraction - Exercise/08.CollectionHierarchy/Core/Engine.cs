using System;
using System.Collections.Generic;

using _08.CollectionHierarchy.Interfaces;
using _08.CollectionHierarchy.Models;

namespace _08.CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<int> addCollectionIndexes;
        private readonly ICollection<int> addRemoveCollectionIndexes;
        private readonly ICollection<int> myListIndexes;
        private readonly ICollection<string> addRemoveCollectionRemovedItems;
        private readonly ICollection<string> myListRemovedItems;
        public Engine()
        {
            this.addCollectionIndexes = new List<int>();
            this.addRemoveCollectionIndexes = new List<int>();
            this.myListIndexes = new List<int>();
            this.addRemoveCollectionRemovedItems = new List<string>();
            this.myListRemovedItems = new List<string>();
        }
        public void Run()
        {
            string[] input = Console.ReadLine().Split(" ");

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var item in input)
            {
                addCollectionIndexes.Add(addCollection.Add(item));
                addRemoveCollectionIndexes.Add(addRemoveCollection.Add(item));
                myListIndexes.Add(myList.Add(item));
            }

            int removeItemsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeItemsCount; i++)
            {
                addRemoveCollectionRemovedItems.Add(addRemoveCollection.Remove());
                myListRemovedItems.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addCollectionIndexes));
            Console.WriteLine(string.Join(" ", addRemoveCollectionIndexes));
            Console.WriteLine(string.Join(" ", myListIndexes));
            Console.WriteLine(string.Join(" ", addRemoveCollectionRemovedItems));
            Console.WriteLine(string.Join(" ", myListRemovedItems));

        }
    }
}
