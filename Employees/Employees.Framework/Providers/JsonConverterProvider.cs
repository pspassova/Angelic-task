using Employees.Framework.Providers.Contracts;
using Newtonsoft.Json;
using System;

namespace Employees.Framework.Providers
{
    public class JsonConverterProvider<T> : IJsonConverter<T> where T : class
    {
        public T DeserializeObject(string file)
        {
            if (file == null)
            {
                throw new ArgumentNullException();
            }

            T convertedData = JsonConvert.DeserializeObject<T>(file);

            return convertedData;
        }
    }
}
