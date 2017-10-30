using Employees.Framework.Providers.Contracts;
using System.IO;

namespace Employees.Framework.Providers
{
    public class FileReaderProvider : IFileReader
    {
        public string Read(string pathToFile)
        {
            string file = null;

            using (StreamReader streamReader = this.GetStreamReader(pathToFile))
            {
                file = streamReader.ReadToEnd();
            }

            return file;
        }

        private StreamReader GetStreamReader(string pathToFile)
        {
            return new StreamReader(pathToFile);
        }
    }
}
