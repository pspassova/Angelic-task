using Employees.Framework.Commands;
using Employees.Framework.Commands.Contracts;
using Employees.Framework.Data;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Providers.Services;
using Employees.Framework.Providers.Services.Contracts;
using Ninject.Modules;
using System.IO;

namespace Employees.Client
{
    public class EmployeesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDisplayEmployeesCommand>().To<DisplayEmployeesCommand>().InSingletonScope();

            this.Bind<IEmployeesDataWrapper>().To<EmployeesDataWrapper>().InSingletonScope();

            this.Bind(typeof(IDataProvider<>)).To(typeof(DataFromFileProvider<>)).InSingletonScope();
            this.Bind(typeof(IJsonConverter<>)).To(typeof(JsonConverterProvider<>)).InSingletonScope();
            this.Bind<IFileReader>().To<FileReaderProvider>().InSingletonScope();
            this.Bind<IConsoleWriter>().To<ConsoleWriterProvider>().InSingletonScope();

            this.Bind<IEmployeeService>().To<EmployeeService>().InSingletonScope();

            this.Bind<StreamReader>().ToSelf();
        }
    }
}
