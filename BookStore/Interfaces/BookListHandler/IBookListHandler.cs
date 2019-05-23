namespace BookStore.Interfaces.BookListHandler
{
    /// <summary>
    /// Handles operations for adding, removing, returing, printing, and saving books to file.
    /// </summary>
    public interface IBookListHandler : IBookCollection, IBookSave
    {
    }
}
