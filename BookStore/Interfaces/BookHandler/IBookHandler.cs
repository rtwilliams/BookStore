
using BookStore.Interfaces.Book;
using System.Collections.Generic;

namespace BookStore.Interfaces.BookHandler
{
    public interface IBookHandler
    {
        void Add(IBook book);
        void Remove(IBook book);
        int BookCount();
        List<IBook> GetBooks();
    }
}
