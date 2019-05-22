
using System.Collections.Generic;
using System.Linq;
using BookStore.DataAccess.Interfaces;
using BookStore.Interfaces.Book;
using BookStore.Interfaces.BookHandler;

namespace BookStore.Classes
{
    public abstract class BookListHandler : IBookHandler
    {
        public IStringDataAccess BookRepository { get; set; }
        public Dictionary<string, IBook> Books { get; set; }

        protected BookListHandler(IStringDataAccess dataRepository)
        {
            BookRepository = dataRepository;
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
    }
}
