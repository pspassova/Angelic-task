using Employees.DataModels.Models;
using System.Collections.Generic;

namespace Employees.Framework.Providers.Services.Contracts
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int id);

        IEnumerable<Employee> GetEmployeesByTeamId(int teamId);

        IEnumerable<Employee> GetEmployeesByLanguage(string language);

        IEnumerable<Employee> GetEmployeesByClient(string client);

        IDictionary<int, List<Employee>> GroupEmployeesByTeamIdOrderedAsc(IEnumerable<Employee> employees);

        void ModifyEmployeeTeam(int employeeId, int newTeamId);

        void UnionTeamsIntoANewOne(int[] teamsIds, int newTeamId);

        int CreateNewTeamId();
    }
}
