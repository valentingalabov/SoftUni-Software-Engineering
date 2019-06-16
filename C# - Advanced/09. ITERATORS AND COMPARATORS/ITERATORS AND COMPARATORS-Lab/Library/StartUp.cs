using System;
using System.Collections.Generic;

namespace Library
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var books = new List<Book>()
            {
                new Book("Harry Potter", 2000, "J.K.Roling"),
                new Book("Dance with Dragons", 2012, "Martin"),
                new Book("I, Robot", 1978, "Azimov"),
                new Book("Programming Basic", 2000, "Svetlin Nakov", "Niki Nedqlkov")

            };

            var library = new Library(books);

            foreach (var book in library)
            {
                Console.WriteLine(book.Title);
            }
            



        }
    }
}
