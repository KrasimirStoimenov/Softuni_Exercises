using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bookShelf = Console.ReadLine()
                .Split('&')
                .ToList();

            Proccessing(bookShelf);

            Console.WriteLine(string.Join(", ", bookShelf));
        }

        static void Proccessing(List<string> shelf)
        {
            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "Add Book":
                        if (!(shelf.Contains(cmdArgs[1])))
                        {
                            AddBook(shelf, cmdArgs[1]);
                        }
                        break;
                    case "Take Book":
                        if (shelf.Contains(cmdArgs[1]))
                        {
                            TakeBook(shelf, cmdArgs[1]);
                        }
                        break;
                    case "Swap Books":
                        if (shelf.Contains(cmdArgs[1]) && shelf.Contains(cmdArgs[2]))
                        {
                            SwapBooks(shelf, cmdArgs[1], cmdArgs[2]);
                        }
                        break;
                    case "Insert Book":
                        shelf.Add(cmdArgs[1]);
                        break;
                    case "Check Book":
                        int index = int.Parse(cmdArgs[1]);
                        if (!(index < 0 || index >= shelf.Count))
                        {
                            Console.WriteLine(shelf[index]);
                        }
                        break;
                }
            }
        }
        static List<string> AddBook(List<string> shelf, string bookName)
        {
            shelf.Insert(0, bookName);
            return shelf;
        }
        static List<string> TakeBook(List<string> shelf, string book)
        {
            shelf.Remove(book);
            return shelf;
        }
        static List<string> SwapBooks(List<string> shelf, string firstBook, string secondBook)
        {
            int firstBookIndex = shelf.FindIndex(x => x == firstBook);
            int secondBookIndex = shelf.FindIndex(s => s == secondBook);

            shelf.Insert(firstBookIndex, secondBook);
            shelf.Remove(firstBook);
            shelf.Insert(secondBookIndex, firstBook);
            shelf.RemoveAt(secondBookIndex + 1);

            return shelf;
        }
    }
}
