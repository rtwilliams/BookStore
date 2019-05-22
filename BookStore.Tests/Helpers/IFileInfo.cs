
using System.Collections.Generic;

namespace BookStore.Tests.Helpers
{
    public interface IFileInfo
    {
        string Read();
        void Write();
        void Delete();
    }
}
