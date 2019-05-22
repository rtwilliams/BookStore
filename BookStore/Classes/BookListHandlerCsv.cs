using System;
using System.Collections.Generic;
using System.Globalization;
using BookStore.DataAccess.Interfaces;
using BookStore.Interfaces.Book;
using BookStore.Interfaces.BookHandler;

namespace BookStore.Classes
{
    public class BookListHandlerCsv : BookListHandler, ISave
    {
        public BookListHandlerCsv(IStringDataAccess dataRepository) : base(dataRepository)
        {
            var bookDataSet = BookRepository.RetrieveDataAsList();
            foreach (var line in bookDataSet)
            {
                AddBook(line);
            }
        }

        public void Save()
        {
            BookRepository.StoreData(GetParsedBookList());
        }

        public IEnumerable<string> GetParsedBookList()
        {
            var parsedBookList = new List<string>();
            foreach (var book in Books)
            {
                parsedBookList.Add(ParseBook(book.Value));
            }
            return parsedBookList;
        }

        // PRIVATE METHODS

        private void AddBook(string bookData)
        {
            var dataFields = bookData.Split(',');
            var book = new Book
            {
                Name = DeParseField(dataFields[0]),
                Author = DeParseField(dataFields[1]),
                BookNumber = Convert.ToInt32(DeParseField(dataFields[2])),
                Condition = (Condition)Enum.Parse(typeof(Condition), DeParseField(dataFields[3])),
                BookType = (BookType)Enum.Parse(typeof(BookType), DeParseField(dataFields[4]))
            };
            base.Add(book);
        }

        private static string ParseBook(IBook book)
        {
            const string delimeter = ",";
            var parsedBook = ParseField(book.Name) + delimeter
                             + ParseField(book.Author) + delimeter
                             + ParseField(book.BookNumber.ToString(CultureInfo.InvariantCulture)) + delimeter
                             + ParseField(book.Condition.ToString()) + delimeter
                             + ParseField(book.BookType.ToString());
            return parsedBook;
        }

        private static string ParseField(string field)
        {
            const string qualifier = "\"";
            return qualifier + field + qualifier;
        }

        private static string DeParseField(string field)
        {
            return field.Replace("\"", "");
        }
    }
}
