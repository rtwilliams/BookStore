using System.Collections.Generic;

namespace BookStore.DataAccess.Interfaces
{
    public interface IStore
    {
        /// <summary>
        /// Stores string data to file.
        /// </summary>
        void StoreData(string lines);

        /// <summary>
        /// Stores list data to file.
        /// </summary>
        void StoreData(IEnumerable<string> lines);
    }
}
