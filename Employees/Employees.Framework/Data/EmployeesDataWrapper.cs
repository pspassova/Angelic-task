using Employees.DataModels.Models;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Framework.Data
{
    public class EmployeesDataWrapper : IEmployeesDataWrapper
    {
        private readonly IDataProvider<Employee> dataProvider;

        public EmployeesDataWrapper(IDataProvider<Employee> dataProvider)
        {
            if (dataProvider == null)
            {
                throw new ArgumentNullException();
            }

            this.dataProvider = dataProvider;
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.dataProvider.GetDataFromJson();
        }

        public Employee GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }
    }
}
