using Employees.DataModels.Models;
using System.Collections.Generic;

namespace Employees.Providers.Contracts
{
    public interface ITeamService
    {
        int CreateNewTeamId(IEnumerable<int> teamsIds);

        IEnumerable<int> GetAllTeamsIds(IEnumerable<Employee> employees);

        void UnionTeamsIntoANewOne(IEnumerable<Employee> employees, IEnumerable<int> teamsIds, int newTeamId);
    }
}
