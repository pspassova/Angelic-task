using Employees.Data.Contracts;
using Employees.DataModels.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Employees.Data
{
    public class EmployeesData : IEmployeesData
    {
        public IEnumerable<Employee> GetEmployeesDataFromJson()
        {
            IEnumerable<Employee> employees = new List<Employee>();

            using (StreamReader file = new StreamReader("../../../../People.txt"))
            {
                string json = file.ReadToEnd();
                employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(json);
            }

            return employees;
        }
    }
}
