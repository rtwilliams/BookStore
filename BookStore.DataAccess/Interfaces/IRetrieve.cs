using System.Collections.Generic;

namespace BookStore.DataAccess.Interfaces
{
    public interface IRetrieve
    {
        /// <summary>
        /// Returns file data as string.
        /// </summary>
        string RetrieveDataAsText();

        /// <summary>
        /// Returns file data as list.
        /// </summary>
        IEnumerable<string> RetrieveDataAsList();
    }
}
