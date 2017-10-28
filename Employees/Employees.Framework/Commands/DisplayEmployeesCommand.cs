using Employees.DataModels.Models;
using Employees.Framework.Commands.Contracts;
using Employees.Framework.Providers.Contracts;
using System;
using System.Collections.Generic;

namespace Employees.Framework.Commands
{
    public class DisplayEmployeesCommand : IDisplayEmployeesCommand
    {
        private readonly IEmployeeService employeeService;
        private readonly ITeamService teamService;
        private readonly IWriter consoleWriter;

        private const int EmployeesWithoutATeamTeamId = -1;

        public DisplayEmployeesCommand(IEmployeeService employeeService, ITeamService teamService, IWriter consoleWriter)
        {
            if (employeeService == null)
            {
                throw new ArgumentNullException();
            }

            if (teamService == null)
            {
                throw new ArgumentNullException();
            }

            if (consoleWriter == null)
            {
                throw new ArgumentNullException();
            }

            this.employeeService = employeeService;
            this.teamService = teamService;
            this.consoleWriter = consoleWriter;
        }

        public void DisplayEmployeesByTeamId(int? teamId)
        {
            if (teamId == null || teamId == -1)
            {
                this.consoleWriter.WriteLine($"\n\r----No team----");
            }
            else
            {
                this.consoleWriter.WriteLine($"\n\r----Team Id {teamId}----");
            }

            IEnumerable<Employee> employeesByTeamId = this.employeeService.GetEmployeesByTeamId(teamId);

            this.DisplayEmployeesNames(employeesByTeamId);
        }

        public void DisplayEmployeesWithoutATeam()
        {
            this.consoleWriter.WriteLine("\n\r----Employees with no team----");
            this.DisplayEmployeesByTeamId(EmployeesWithoutATeamTeamId);
        }

        public void DisplayTeamsFilteredByLanguage(string language)
        {
            IEnumerable<Employee> employeesFilteredByLanguage = this.employeeService.GetEmployeesByLanguage(language);
            IDictionary<int, List<Employee>> employeesByLanguageGroupedByTeam = this.employeeService.GroupEmployeesByTeamIdOrderedAsc(employeesFilteredByLanguage);

            this.consoleWriter.WriteLine($"\n\r----Employees who speak {language}----");

            foreach (int teamId in employeesByLanguageGroupedByTeam.Keys)
            {
                this.DisplayEmployeesByTeamId(employeesByLanguageGroupedByTeam[teamId], teamId);
            }
        }

        public void DisplayTeamsFilteredByClient(string client)
        {
            IEnumerable<Employee> employeesFilteredByClient = this.employeeService.GetEmployeesByClient(client);
            IDictionary<int, List<Employee>> employeesByClientGroupedByTeam = this.employeeService.GroupEmployeesByTeamIdOrderedAsc(employeesFilteredByClient);

            this.consoleWriter.WriteLine($"\n\r----Employees with client {client}----");

            foreach (int teamId in employeesByClientGroupedByTeam.Keys)
            {
                this.DisplayEmployeesByTeamId(employeesByClientGroupedByTeam[teamId], teamId);
            }
        }

        public void DisplayModifyEmloyeeTeamResult(int employeeId, int newTeamId)
        {
            this.employeeService.ModifyEmployeeTeam(employeeId, newTeamId);

            this.consoleWriter.WriteLine($"\n\r----Modify employee's team----");
            this.consoleWriter.WriteLine($"\n\rEmployee with ID {employeeId} has changed it's team ID to {newTeamId}");
        }

        public void DisplayUnionTeamsResult(int[] teamsIds)
        {
            int newTeamId = this.teamService.CreateNewTeamId();
            this.teamService.UnionTeamsIntoANewOne(teamsIds, newTeamId);

            this.consoleWriter.WriteLine($"\n\r---Union teams with team IDs {String.Join(", ", newTeamId)} into a new one----");
            this.DisplayEmployeesByTeamId(newTeamId);
        }

        private void DisplayEmployeesByTeamId(IEnumerable<Employee> employees, int? teamId)
        {

            if (teamId == null || teamId == -1)
            {
                this.consoleWriter.WriteLine($"\n\r----No team----");
            }
            else
            {
                this.consoleWriter.WriteLine($"\n\r----Team Id {teamId}----");
            }

            this.DisplayEmployeesNames(employees);
        }

        private void DisplayEmployeesNames(IEnumerable<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                this.consoleWriter.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
        }
    }
}
