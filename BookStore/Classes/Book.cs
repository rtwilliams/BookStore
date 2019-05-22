using System;
using BookStore.Interfaces.Book;

namespace BookStore.Classes
{
    public class Book : IBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int BookNumber { get; set; }
        public Condition Condition { get; set; }
        public BookType BookType { get; set; }
        private bool _checkedOut;

        public Book()
        {
        }

        public Book(string name, string author, int number, Condition condition, BookType booktype)
        {
            Name = name;
            Author = author;
            BookNumber = number;
            Condition = condition;
            BookType = booktype;
        }
        
        public void CheckOut()
        {
            _checkedOut = true;
        }

        public void Return()
        {
            _checkedOut = false;
        }

        public void Print()
        {
            var printString = "Book: " + Name + Environment.NewLine
                                + "Author: " + Author + Environment.NewLine 
                                + "Condition: " + Condition + Environment.NewLine
                                + "Type: " + BookType + Environment.NewLine
                                + Environment.NewLine;
            Console.Write(printString);
        }

        public bool IsCheckedOut()
        {
            return _checkedOut;
        }
    }
}
