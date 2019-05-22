
namespace BookStore.Interfaces.Book
{
    public enum BookType { PaperBack, HardCover, Popup }
    public enum Condition { Excellent, Good, Fair, Poor }

    public interface IBook
    {
        string Name { get; set; }
        string Author { get; set; }
        int BookNumber { get; set; }
        Condition Condition { get; set; }
        BookType BookType { get; set; }

        void CheckOut();
        void Return();
        void Print();
        bool IsCheckedOut();
    }
}
