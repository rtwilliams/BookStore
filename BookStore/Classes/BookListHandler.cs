using System.Collections.Generic;
using System.Linq;
using BookStore.Interfaces.Book;
using BookStore.Interfaces.BookListHandler;

namespace BookStore.Classes
{
    public abstract class BookListHandler : IBookCollection
    {
        public Dictionary<string, IBook> Books { get; set; }

        protected BookListHandler()
        {
            Books = new Dictionary<string, IBook>();
        }

        public void Add(IBook book)
        {
            if (!Books.ContainsKey(book.Name))
                Books.Add(book.Name, book);
        }

        public void Remove(IBook book)
        {
            Books.Remove(book.Name);
        }        

        public int BookCount()
        {
            return Books.Count;
        }

        public List<IBook> GetBooks()
        {
            return Books.Values.ToList();
        }

        public void PrintBooks()
        {
            foreach(var book in GetBooks())
            {
                book.Print();
            }
        }
    }
}
