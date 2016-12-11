using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPatterns.FactoryMethod;

namespace DesignPatterns.FactoryMethod
{
    public abstract class BookReader
    {
        public BookReader()
        {
            Book = BuyBook();
        }

        public Book Book { get; set; }

        public abstract Book BuyBook();

        public Book BuyBook<T>()
            where T : Book, new()
        {
            return new T();
        }
             
        
        public void DisplayOwnedBooks()
        {
            Console.WriteLine(Book.GetType().ToString());
        }
    }
}
