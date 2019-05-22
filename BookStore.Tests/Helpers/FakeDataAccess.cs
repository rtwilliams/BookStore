using System.Collections.Generic;
using BookStore.DataAccess.Interfaces;

namespace BookStore.Tests.Helpers
{
    class FakeDataAccess : IStringDataAccess
    {
        private readonly IFileInfo _file; 

        public FakeDataAccess(IFileInfo file)
        {
            _file = file;
        }

        public void StoreData(string lines)
        {
            _file.Write();
        }

        public void StoreData(IEnumerable<string> lines)
        {
            _file.Write();
        }

        public void Delete()
        {
            _file.Delete();
        }

        public string RetrieveDataAsText()
        {
            return _file.Read();
        }

        public IEnumerable<string> RetrieveDataAsList()
        {
           return new List<string>();
        }
    }
}
