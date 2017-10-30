using Employees.Framework.Providers.Contracts;
using System;

namespace Employees.Framework.Providers
{
    public class ConsoleWriterProvider : IConsoleWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
