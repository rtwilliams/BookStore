using System.Collections.Generic;
using System.Linq;
using BookStore.Classes;
using BookStore.Interfaces.Book;
using BookStore.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookStore.Tests
{
    [TestClass]
    public class BookHandlerFromCsvTests
    {
        public Dictionary<string, IBook> ReturnPopulatedBookList()
        {
            return new Dictionary<string, IBook>
            {
                { "Book1", new Book("Book1", "Author1", 1, Condition.Good, BookType.HardCover) },
                { "Book2", new Book("Book2", "Author2", 2, Condition.Fair, BookType.PaperBack) },
                { "Book3", new Book("Book3", "Author3", 3, Condition.Poor, BookType.Popup) }
            };
        }

        [TestMethod]
        public void AddBookToBookListTest()
        {
            var mock = new Mock<IFileInfo>();
            var dataAccess = new FakeDataAccess(mock.Object); 
            var bookHandler = new BookListHandlerCsv(dataAccess);
            var book = new Book("Book4", "Author4", 1, Condition.Good, BookType.HardCover);
            bookHandler.Add(book);
            Assert.IsTrue(bookHandler.Books.Count == 1);
        }

        [TestMethod]
        public void RemoveBookFromListTest()
        {
            var mock = new Mock<IFileInfo>();
            var dataAccess = new FakeDataAccess(mock.Object);
            var bookHandler = new BookListHandlerCsv(dataAccess) { Books = ReturnPopulatedBookList() };
            var bookListCountBeforeRemove = bookHandler.Books.Count;
            var book = bookHandler.Books.ElementAt(0).Value;
            bookHandler.Remove(book);
            var bookListCountAfterRemove = bookHandler.Books.Count;
            Assert.IsTrue(bookListCountBeforeRemove > bookListCountAfterRemove);
        }

        [TestMethod]
        public void ReturnParsedBookListTest()
        {
            var mock = new Mock<IFileInfo>();
            var dataAccess = new FakeDataAccess(mock.Object);
            var bookHandler = new BookListHandlerCsv(dataAccess) { Books = ReturnPopulatedBookList() };
            var parsedBookList = bookHandler.GetParsedBookList();
            Assert.IsTrue(parsedBookList.Any());
        }
    }
}
