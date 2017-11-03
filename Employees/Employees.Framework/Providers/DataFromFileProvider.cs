using Employees.Framework.Providers.Contracts;
using System;
using System.Collections.Generic;

namespace Employees.Framework.Providers
{
    public class DataFromFileProvider<T> : IDataProvider<T> where T : class
    {
        private readonly IFileReader fileReader;
        private readonly IJsonConverter<IEnumerable<T>> jsonConverter;

        private const string DataFilePath = "../../../../JsonData/People.txt"; 

        public DataFromFileProvider(IFileReader fileReader, IJsonConverter<IEnumerable<T>> jsonConverter)
        {
            if (fileReader == null)
            {
                throw new ArgumentNullException();
            }

            if (jsonConverter == null)
            {
                throw new ArgumentNullException();
            }

            this.fileReader = fileReader;
            this.jsonConverter = jsonConverter;
        }

        public IEnumerable<T> GetDataFromJson() // should get the path from somewhere else !!! FIX THIS
        {
            string file = this.fileReader.Read(DataFilePath);
            IEnumerable<T> data = this.jsonConverter.DeserializeObject(file); // NOT TESTED

            return data;
        }
    }
}
