using Employees.DataModels.Models;
using System.Collections.Generic;

namespace Employees.Data.Contracts
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> GetEmployeesDataFromJson();
    }
}
