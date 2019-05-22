using BookStore.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookStore.Tests
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void DataAccessRetrieveData()
        {
            var mock = new Mock<IFileInfo>();
            var dataAccess = new FakeDataAccess(mock.Object);
            mock.Setup(x => x.Read());
            dataAccess.RetrieveDataAsText();
            mock.Verify(x => x.Read(), Times.Once);
        }

        [TestMethod]
        public void DataAccessStoreData()
        {
            var mock = new Mock<IFileInfo>();
            var dataAccess = new FakeDataAccess(mock.Object);
            mock.Setup(x => x.Write());
            dataAccess.StoreData("Test");
            mock.Verify(x => x.Write(), Times.Once);
        }

        [TestMethod]
        public void DataAccessDeleteDataFile()
        {
            var mock = new Mock<IFileInfo>();
            var dataAccess = new FakeDataAccess(mock.Object);
            mock.Setup(x => x.Delete());
            dataAccess.Delete();
            mock.Verify(x => x.Delete(), Times.Once);
        }
    }
}
