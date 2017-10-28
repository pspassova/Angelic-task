using Employees.DataModels.Models;
using System.Collections.Generic;

namespace Employees.Providers.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployeesByTeamId(IEnumerable<Employee> employees, int teamId);

        IEnumerable<Employee> GetEmployeesByLanguage(IEnumerable<Employee> employees, string language);

        IEnumerable<Employee> GetEmployeesByClient(IEnumerable<Employee> employees, string client);

        IDictionary<int, List<Employee>> GroupEmployeesByTeamIdOrderedAsc(IEnumerable<Employee> employees);

        void UpdateEmployeeTeam(IEnumerable<Employee> employees, int employeeId, int newTeamId);
    }
}
