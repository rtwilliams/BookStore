using System.Collections.Generic;
using BookStore.DataAccess.Interfaces;
using BookStore.Interfaces.BookHandler;
using Newtonsoft.Json;

namespace BookStore.Classes
{
    public class BookListHandlerJson : BookListHandler, ISave
    {
        public BookListHandlerJson(IStringDataAccess dataRepository) : base(dataRepository)
        {
            var fileText = BookRepository.RetrieveDataAsText();
            if (fileText.Length == 0) return;

            var books = JsonConvert.DeserializeObject<Dictionary<string, Book>>(fileText);
            foreach (var book in books.Values)
            {
                base.Add(book);
            }
        }

        public void Save()
        {
            BookRepository.StoreData(GetParsedBookList());
        }

        public string GetParsedBookList()
        {
            return JsonConvert.SerializeObject(Books);
        }
    }
}
