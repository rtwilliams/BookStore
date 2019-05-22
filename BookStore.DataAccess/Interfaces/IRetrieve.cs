
using System.Collections.Generic;

namespace BookStore.DataAccess.Interfaces
{
    public interface IRetrieve
    {
        string RetrieveDataAsText();
        IEnumerable<string> RetrieveDataAsList();
    }
}
