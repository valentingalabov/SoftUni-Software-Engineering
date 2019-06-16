using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public IEnumerator<Book> GetEnumerator()
        {
            var libraryEnumerator = new LibraryIterator(books);

            return libraryEnumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Library(List<Book> books)
        {
            this.books = books;
        }
    }
}
