using BookStore.Interfaces.Book;
using System.Collections.Generic;

namespace BookStore.Interfaces.BookListHandler
{
    /// <summary>
    /// Handles operations for adding, removing, returing, printing book list. 
    /// </summary>
    public interface IBookCollection
    {
        /// <summary>
        /// Adds a book to the list.
        /// </summary>
        void Add(IBook book);

        /// <summary>
        /// Removes book from the list.
        /// </summary>
        void Remove(IBook book);

        /// <summary>
        /// Returns amount of books in list.
        /// </summary>
        int BookCount();

        /// <summary>
        /// Returns book list.
        /// </summary>
        List<IBook> GetBooks();

        /// <summary>
        /// Prints book list. 
        /// </summary>
        void PrintBooks();
    }
}
