using BookStore.DataAccess.Interfaces;
using BookStore.Interfaces.BookListHandler;
using Newtonsoft.Json;

namespace BookStore.Classes
{
    /// <summary>
    /// Handles operations for adding, removing, returing, printing, and saving book list to json file.
    /// </summary>
    public class BookListHandlerJson : BookListHandler, IBookListHandler
    {
        public IStringDataAccess BookRepository { get; set; }

        public BookListHandlerJson(IStringDataAccess dataRepository)
        {
            BookRepository = dataRepository;
        }

        public void Save()
        {
            BookRepository.StoreData(GetParsedBookList());
        }

        /// <summary>
        /// Returns a parsed list of books. 
        /// </summary>
        public string GetParsedBookList()
        {
            return JsonConvert.SerializeObject(Books);
        }
    }
}
