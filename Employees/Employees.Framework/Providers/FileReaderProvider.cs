using Employees.Framework.Providers.Contracts;
using System;
using System.IO;

namespace Employees.Framework.Providers
{
    public class FileReaderProvider : IFileReader
    {
        //private readonly StreamReader streamReader;

        public FileReaderProvider()
        {
            //if (streamReader == null)
            //{
            //    throw new ArgumentNullException();
            //}

            //this.streamReader = streamReader;
        }

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
