using System;
using System.IO;
using BookStore.Classes;
using BookStore.DataAccess;
using BookStore.Interfaces.Book;
using BookStore.Interfaces.BookListHandler;

namespace BookStore
{
    class Program
    {
        private const int bookMax = 5;
        private static readonly Random random = new Random();

        static void Main()
        {
            RunFlatFileExample();
            RunJsonFileExample();
        }

        /// <summary>
        /// Adds books to collection; optionally removes a book; and saves book collection to csv file.
        /// Reads book collection from file and prints output to screen.
        /// </summary>
        private static void RunFlatFileExample()
        {
            Console.WriteLine("Flat File Example");
            Console.WriteLine("-----------------");

            // Create text (csv) file handler 
            var textFileBookDbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookDB.csv");
            var textFileBookDb = new FileInfo(textFileBookDbDirectoryPath);
            var bookListHandlerCsv = new BookListHandlerCsv(new DataFileRepository(textFileBookDb));

            ProcessFile(bookListHandlerCsv, random);

            // Retrieve and output books from Text file
            Console.WriteLine("Writing from Text File");
            Console.WriteLine("----------------------");
            bookListHandlerCsv.PrintBooks();
        }

        /// <summary>
        /// Adds books to collection; optionally removes a book; and saves book collection to json file.
        /// Reads book collection from file and prints output to screen.
        /// </summary>
        private static void RunJsonFileExample()
        {
            Console.WriteLine("Json File Example");
            Console.WriteLine("-----------------");

            // Create json handler
            var jsonBookDbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookDB.json");
            var jsonBookDb = new FileInfo(jsonBookDbDirectoryPath);
            var jsonFileBookHandler = new BookListHandlerJson(new DataFileRepository(jsonBookDb));

            ProcessFile(jsonFileBookHandler, random);

            // Retrieve and output books from Json File
            Console.WriteLine("Writing from Json File");
            Console.WriteLine("----------------------");
            jsonFileBookHandler.PrintBooks();
        }

        /// <summary>
        /// Adds books to collection; optionally removes a book; saves book collection to file.
        /// </summary>
        /// <param name="bookHander">Handler for processing books</param>
        /// <param name="random">Random number generator</param>
        private static void ProcessFile(IBookListHandler bookHander, Random random)
        {
            IBook ranBook;
            int dictIndex = 0;
            for (int i = 0; i < bookMax; i++)
            {
                ranBook = GetRandomBook(random.Next(bookMax));
                bookHander.Add(ranBook);
                if (bookHander.BookCount() > dictIndex)
                {
                    Console.WriteLine("Added book: " + ranBook.Name);
                    dictIndex++;
                }
            }
            ranBook = GetRandomBook(random.Next(bookMax));
            bookHander.Remove(ranBook);
            if (bookHander.BookCount() < dictIndex)
                Console.WriteLine("Removed book: " + ranBook.Name);

            bookHander.Save();
            Console.WriteLine("Books Saved to File!");
            Console.WriteLine("");
        }

        /// <summary>
        /// Returns a book by number passed in.
        /// </summary>
        /// <param name="randomIndex">Random number between 0 and bookMax</param>
        private static IBook GetRandomBook(int randomIndex)
        {
            switch (randomIndex)
            {
                case 0:
                    return MobyDick();
                case 1:
                    return DesignPatternsInJava();
                case 2:
                    return MechantOfVenice();
                case 3:
                    return CrimesAndPunishment();
                case 4:
                    return SallyTheSelfishShellfish();
                default:
                    return Unknown();
            }
        }

        private static IBook MobyDick()
        {
            return new Book("Moby Dick", "Herman Melville", 1, Condition.Good, BookType.PaperBack);
        }

        private static IBook DesignPatternsInJava()
        {
            return new Book("Design Patterns in Java", "Unknow", 2, Condition.Fair, BookType.HardCover);
        }

        private static IBook MechantOfVenice()
        {
            return new Book("Merchant of Venice", "William Shakespeare", 3, Condition.Poor, BookType.PaperBack);
        }

        private static IBook CrimesAndPunishment()
        {
            return new Book("Crimes and Punishment", "Fyodor Dostoevsky", 4, Condition.Excellent, BookType.PaperBack);
        }

        private static IBook SallyTheSelfishShellfish()
        {
            return new Book("Sally the Selfish Shellfish", "Robert Williams", 5, Condition.Fair, BookType.Popup);
        }

        private static IBook Unknown()
        {
            return new Book("Unknown Title", "Unknown Author", 0, Condition.Poor, BookType.HardCover);
        }
    }
}
