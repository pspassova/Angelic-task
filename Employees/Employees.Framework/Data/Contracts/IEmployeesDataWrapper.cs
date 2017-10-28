using Employees.DataModels.Models;
using System.Collections.Generic;

namespace Employees.Framework.Data.Contracts
{
    public interface IEmployeesDataWrapper
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(int id);
    }
}
