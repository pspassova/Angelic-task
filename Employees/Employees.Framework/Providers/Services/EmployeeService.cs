using System;
using System.Collections.Generic;
using System.Linq;
using Employees.DataModels.Models;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers.Services.Contracts;

namespace Employees.Framework.Providers.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesDataWrapper employeesDataWrapper;

        private IEnumerable<Employee> employeesCollection;

        public EmployeeService(IEmployeesDataWrapper employeesDataWrapper)
        {
            if (employeesDataWrapper == null)
            {
                throw new ArgumentNullException();
            }

            this.employeesDataWrapper = employeesDataWrapper;
            this.employeesCollection = this.employeesDataWrapper.GetAll();
        }

        public IEnumerable<Employee> EmployeesCollection
        {
            get
            {
                return this.employeesCollection;
            }
            set
            {
                this.employeesCollection = value;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            return this.employeesDataWrapper.GetById(id);
        }

        public IEnumerable<Employee> GetEmployeesByTeamId(int teamId)
        {
            return this.EmployeesCollection.Where(e => e.TeamId == teamId);
        }

        public IEnumerable<Employee> GetEmployeesByClient(string client)
        {
            if (client == null)
            {
                throw new ArgumentNullException();
            }

            client = client.ToLower();
            IEnumerable<Employee> employeesByClient = this.EmployeesCollection.Where(e => e.Client.ToLower() == client);

            return employeesByClient;
        }

        public IEnumerable<Employee> GetEmployeesByLanguage(string language)
        {
            if (language == null)
            {
                throw new ArgumentNullException();
            }

            language = language.ToLower();
            IEnumerable<Employee> employeesByLanguage = this.EmployeesCollection.Where(e => e.Language.ToLower() == language);

            return employeesByLanguage;
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

        public void ModifyEmployeeTeam(int employeeId, int newTeamId)
        {
            Employee employee = this.EmployeesCollection.SingleOrDefault(e => e.Id == employeeId);

            employee.TeamId = newTeamId;
        }

        public int CreateNewTeamId()
        {
            int newTeamId = this.GetAllTeamsIds().OrderBy(id => id).LastOrDefault();
            ++newTeamId;

            return newTeamId;
        }

        public void UnionTeamsIntoANewOne(int[] teamsIds, int newTeamId)
        {
            IEnumerable<Employee> employees = this.EmployeesCollection;
            foreach (int teamId in teamsIds)
            {
                IEnumerable<Employee> employeesWithId = employees.Where(e => e.TeamId == teamId);
                foreach (Employee employee in employeesWithId)
                {
                    this.ModifyEmployeeTeam(employee.Id, newTeamId);
                }
            }
        }

        private IEnumerable<int> GetAllTeamsIds()
        {
            IEnumerable<int> teamsIds = this.EmployeesCollection.Select(e => e.TeamId);

            return teamsIds;
        }
    }
}
