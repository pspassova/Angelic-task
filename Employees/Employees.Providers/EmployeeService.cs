using Employees.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Employees.DataModels.Models;

namespace Employees.Providers
{
    public class EmployeeService : IEmployeeService
    {
        private const int EmployeesWithoutATeamTeamId = -1;

        public IEnumerable<Employee> GetEmployeesByClient(IEnumerable<Employee> employees, string client)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<Employee> employeesByClient = employees.Where(e => e.Client == client);

            return employeesByClient;
        }

        public IEnumerable<Employee> GetEmployeesByLanguage(IEnumerable<Employee> employees, string language)
        {
            if (language == null)
            {
                throw new ArgumentNullException();
            }

            language = language.ToLower();
            IEnumerable<Employee> employeesByLanguage = employees.Where(e => e.Language.ToLower() == language);

            return employeesByLanguage;
        }

        public IEnumerable<Employee> GetEmployeesByTeamId(IEnumerable<Employee> employees, int teamId)
        {
            IEnumerable<Employee> employeesInTeam = employees.Where(e => e.TeamId == teamId);

            return employeesInTeam;
        }

        public IEnumerable<Employee> GetEmployeesWithoutATeam(IEnumerable<Employee> employees)
        {
            IEnumerable<Employee> employeesWithoutATeam = this.GetEmployeesByTeamId(employees, EmployeesWithoutATeamTeamId);

            return employeesWithoutATeam;
        }

        public IDictionary<int, List<Employee>> GroupEmployeesByTeamIdOrderedAsc(IEnumerable<Employee> employees)
        {
            SortedDictionary<int, List<Employee>> groups = new SortedDictionary<int, List<Employee>>();

            foreach (Employee employee in employees)
            {
                if (!groups.ContainsKey(employee.TeamId))
                {
                    groups.Add(employee.TeamId, new List<Employee> { employee });
                }

                else
                {
                    groups[employee.TeamId].Add(employee);
                }
            }

            return groups;
        }

        public void UpdateEmployeeTeam(IEnumerable<Employee> employees, int employeeId, int newTeamId)
        {
            employees.SingleOrDefault(e => e.Id == employeeId).TeamId = newTeamId;
        }
    }
}
