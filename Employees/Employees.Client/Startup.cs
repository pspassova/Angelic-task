using Employees.DataModels.Models;
using Employees.Framework.Commands;
using Employees.Framework.Commands.Contracts;
using Employees.Framework.Data;
using Employees.Framework.Providers;
using System.Collections.Generic;

namespace Employees.Client
{
    public static class Startup
    {
        public static void Main()
        {
            var fileReader = new FileReaderProvider();
            var jsonConverter = new JsonConverterProvider<IEnumerable<Employee>>();
            var dataProvider = new DataFromFileProvider<Employee>(fileReader, jsonConverter);
            var dataWrapper = new EmployeesDataWrapper(dataProvider);
            var employeeService = new EmployeeService(dataWrapper);
            var teamService = new TeamService(dataWrapper);
            var consoleWriter = new ConsoleWriterProvider();

            IDisplayEmployeesCommand employeesCommand = new DisplayEmployeesCommand(employeeService, teamService, consoleWriter);

            employeesCommand.DisplayEmployeesByTeamId(30);

            employeesCommand.DisplayModifyEmloyeeTeamResult(1, 22); 
            employeesCommand.DisplayEmployeesByTeamId(30);

            employeesCommand.DisplayEmployeesWithoutATeam();

            employeesCommand.DisplayTeamsFilteredByLanguage("Bulgarian");

            employeesCommand.DisplayTeamsFilteredByClient("Yakidoo");

            employeesCommand.DisplayUnionTeamsResult(new int[] { 30, 44 }); // there are different instances for the teams service and the display class


        }
    }
}
