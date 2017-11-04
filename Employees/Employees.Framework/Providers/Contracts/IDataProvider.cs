using System.Collections.Generic;

namespace Employees.Framework.Providers.Contracts
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetDataFromJson(string pathToFile);
    }
}
