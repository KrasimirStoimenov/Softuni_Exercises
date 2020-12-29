using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;
        public Library(params Book[] books)
        {
            this.Books = books.ToList();
            this.Books.Sort();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;
            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext()
            {

                return ++this.currentIndex < this.books.Count;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }

}
