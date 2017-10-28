namespace Employees.Framework.Providers.Contracts
{
    public interface IJsonConverter<T>
    {
        T DeserializeObject(string file);
    }
}
