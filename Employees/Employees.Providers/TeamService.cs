using Employees.Providers.Contracts;
using System.Collections.Generic;
using System.Linq;
using Employees.DataModels.Models;

namespace Employees.Providers
{
    public class TeamService : ITeamService
    {
        public int CreateNewTeamId(IEnumerable<int> teamsIds)
        {
            int newTeamId = teamsIds.OrderBy(id => id).LastOrDefault();
            ++newTeamId;

            return newTeamId;
        }

        public IEnumerable<int> GetAllTeamsIds(IEnumerable<Employee> employees)
        {
            IEnumerable<int> teamsIds = employees.Select(e => e.TeamId);

            return teamsIds;
        }

        public void UnionTeamsIntoANewOne(IEnumerable<Employee> employees, IEnumerable<int> teamsIds, int newTeamId)
        {
            foreach (int teamId in teamsIds)
            {
                employees.Where(e => e.TeamId == teamId).ToList().ForEach(e => e.TeamId = newTeamId);
            }
        }
    }
}
