using System.Collections.Generic;
using System.Linq;
using Employees.DataModels.Models;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Data.Contracts;
using System;

namespace Employees.Framework.Providers
{
    public class TeamService : ITeamService
    {
        private readonly IEmployeesDataWrapper employeesDataWrapper;

        public TeamService(IEmployeesDataWrapper employeesDataWrapper)
        {
            if (employeesDataWrapper == null)
            {
                throw new ArgumentNullException();
            }

            this.employeesDataWrapper = employeesDataWrapper;
        }

        public int CreateNewTeamId()
        {
            int newTeamId = this.GetAllTeamsIds().OrderBy(id => id).LastOrDefault();
            ++newTeamId;

            return newTeamId;
        }

        public void UnionTeamsIntoANewOne(int[] teamsIds, int newTeamId)
        {
            IEnumerable<Employee> employees = this.employeesDataWrapper.GetAll();
            foreach (int teamId in teamsIds)
            {
                employees.Where(e => e.TeamId == teamId).ToList().ForEach(e => e.TeamId = newTeamId);
            }
        }

        private IEnumerable<int> GetAllTeamsIds()
        {
            IEnumerable<int> teamsIds = this.employeesDataWrapper.GetAll().Select(e => e.TeamId);

            return teamsIds;
        }
    }
}
