using Employees.DataModels.Models;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Employees.Tests.Framework.Providers.Services.EmployeeServiceTests
{
    [TestFixture]
    public class EmployeesCollection_Should
    {
        [Test]
        public void ReturnAllEmployeesFromDataWrapper()
        {
            // Arrange
            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            var expectedEmployees = new List<Employee> { new Mock<Employee>().Object };
            employeesDataWrapperMock.Setup(x => x.GetAll()).Returns(expectedEmployees);

            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            // Act
            IEnumerable<Employee> actualEmployees = employeeService.EmployeesCollection;

            // Assert
            CollectionAssert.AreEquivalent(expectedEmployees, actualEmployees);
        }
    }
}
