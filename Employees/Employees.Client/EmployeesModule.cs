using Employees.Framework.Commands;
using Employees.Framework.Commands.Contracts;
using Employees.Framework.Data;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers;
using Employees.Framework.Providers.Contracts;
using Ninject.Modules;
using System.IO;

namespace Employees.Client
{
    public class EmployeesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDisplayEmployeesCommand>().To<DisplayEmployeesCommand>().InSingletonScope();

            this.Bind(typeof(IDataProvider<>)).To(typeof(DataFromFileProvider<>));

            this.Bind<IFileReader>().To<FileReaderProvider>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            this.Bind(typeof(IJsonConverter<>)).To(typeof(JsonConverterProvider<>));
            this.Bind<IEmployeesDataWrapper>().To<EmployeesDataWrapper>().InSingletonScope();
            this.Bind<IEmployeeService>().To<EmployeeService>().InSingletonScope();
            this.Bind<ITeamService>().To<TeamService>().InSingletonScope();

            this.Bind<StreamReader>().ToSelf();
        }
    }
}
