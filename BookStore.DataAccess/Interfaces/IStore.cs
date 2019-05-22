
using System.Collections.Generic;

namespace BookStore.DataAccess.Interfaces
{
    public interface IStore
    {
        void StoreData(string lines);
        void StoreData(IEnumerable<string> lines);
    }
}
