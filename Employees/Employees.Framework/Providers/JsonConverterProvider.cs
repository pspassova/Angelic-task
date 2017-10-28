using Employees.Framework.Providers.Contracts;
using Newtonsoft.Json;

namespace Employees.Framework.Providers
{
    public class JsonConverterProvider<T> : IJsonConverter<T> where T : class
    {
        public T DeserializeObject(string file)
        {
            T convertedData = JsonConvert.DeserializeObject<T>(file);

            return convertedData;
        }
    }
}
