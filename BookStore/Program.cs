using System;
using System.IO;
using BookStore.Classes;
using BookStore.DataAccess;
using BookStore.Interfaces.Book;

namespace BookStore
{
    class Program
    {
        private const int bookMax = 5;

        static void Main()
        {
            var random = new Random();
            RunFlatFileExample(random);
            RunJsonFileExample(random);
        }

        private static void RunFlatFileExample(Random random)
        {
            Console.WriteLine("Flat File Example");
            Console.WriteLine("-----------------");

            // Save as Text file 
            var textFileBookDbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookDB.csv");
            var textFileBookDb = new FileInfo(textFileBookDbDirectoryPath);
            var bookListHandlerCsv = new BookListHandlerCsv(new DataFileRepository(textFileBookDb));

            IBook ranBook;
            int dictIndex = 0;
            for (int i = 0; i < bookMax; i++)
            {
                ranBook = GetRandomBook(random.Next(bookMax));
                bookListHandlerCsv.Add(ranBook);
                if (bookListHandlerCsv.BookCount() > dictIndex)
                {
                    Console.WriteLine("Added book: " + ranBook.Name);
                    dictIndex++;
                }
            }
            ranBook = GetRandomBook(random.Next(bookMax));
            bookListHandlerCsv.Remove(ranBook);
            if (bookListHandlerCsv.BookCount() < dictIndex)
                Console.WriteLine("Removed book: " + ranBook.Name);

            bookListHandlerCsv.Save();
            Console.WriteLine("Books Saved to Text File!");
            Console.WriteLine("");

            // Retrieve and output books from Text file
            Console.WriteLine("Writing from Text File");
            Console.WriteLine("----------------------");
            textFileBookDb = new FileInfo(textFileBookDbDirectoryPath);
            bookListHandlerCsv = new BookListHandlerCsv(new DataFileRepository(textFileBookDb));
            foreach (var book in bookListHandlerCsv.GetBooks())
            {
                book.Print();
            }
        }

        private static void RunJsonFileExample(Random random)
        {
            Console.WriteLine("Json File Example");
            Console.WriteLine("-----------------");

            // Save as Json file
            var jsonBookDbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookDB.json");
            var jsonBookDb = new FileInfo(jsonBookDbDirectoryPath);
            var jsonFileBookHandler = new BookListHandlerJson(new DataFileRepository(jsonBookDb));

            IBook ranBook;
            int dictIndex = 0;
            for (int i = 0; i < bookMax; i++)
            {
                ranBook = GetRandomBook(random.Next(bookMax));
                jsonFileBookHandler.Add(ranBook);
                if (jsonFileBookHandler.BookCount() > dictIndex)
                {
                    Console.WriteLine("Added book: " + ranBook.Name);
                    dictIndex++;
                }
            }
            ranBook = GetRandomBook(random.Next(bookMax));
            jsonFileBookHandler.Remove(ranBook);
            if (jsonFileBookHandler.BookCount() < dictIndex)
                Console.WriteLine("Removed book: " + ranBook.Name);

            jsonFileBookHandler.Save();
            Console.WriteLine("Books Saved to Json File!");
            Console.WriteLine("");

            // Retrieve and output books from Json File
            Console.WriteLine("Writing from Json File");
            Console.WriteLine("----------------------");
            jsonBookDb = new FileInfo(jsonBookDbDirectoryPath);
            jsonFileBookHandler = new BookListHandlerJson(new DataFileRepository(jsonBookDb));
            foreach (var book in jsonFileBookHandler.GetBooks())
            {
                book.Print();
            }
        }

        private static IBook GetRandomBook(int i)
        {
            switch (i)
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
