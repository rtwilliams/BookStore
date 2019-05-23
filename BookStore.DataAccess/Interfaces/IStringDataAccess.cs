namespace BookStore.DataAccess.Interfaces
{
    /// <summary>
    /// Responsible for accessing, storing, and deleting data from a file.
    /// </summary>
    public interface IStringDataAccess : IRetrieve, IStore, IDelete
    {
    }
}
