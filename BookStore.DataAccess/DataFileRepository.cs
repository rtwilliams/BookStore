
using System.Collections.Generic;
using System.IO;
using System.Text;
using BookStore.DataAccess.Interfaces;

namespace BookStore.DataAccess
{
    public class DataFileRepository : IStringDataAccess
    {
        private readonly FileInfo _file;

        public DataFileRepository(FileInfo file)
        {
            _file = file;
        }

        public string RetrieveDataAsText()
        {
            if (!_file.Exists) return string.Empty;
            var fileText = new StringBuilder();
            using (var streamReader = _file.OpenText())
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    fileText.Append(line);
                }
            }
            return fileText.ToString();
        }

        public IEnumerable<string> RetrieveDataAsList()
        {
            if (!_file.Exists) return new List<string>();
            var lines = new List<string>();
            using (var streamReader = _file.OpenText())
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }

        public void StoreData(string fileText)
        {
            using (var streamWriter = _file.CreateText())
            {
                streamWriter.Write(fileText);
            }
        }

        public void StoreData(IEnumerable<string> lines)
        {
            using (var streamWriter = _file.CreateText())
            {
                foreach (var line in lines)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }

        public void Delete()
        {
            _file.Delete();
        }
    }
}
