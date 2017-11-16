using Employees.DataModels.Models;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Tests.Framework.Providers.Services.EmployeeServiceTests
{
    [TestFixture]
    public class GetEmployeesByTeamId_Should
    {
        [Test]
        public void ReturnTheCorrectEmployee_WhenEmployeeIdIsProvided()
        {
            // Arrange
            int[] testEmployeesTeamIds = new int[] { 1, 5 };

            var firstEmployeeMock = new Mock<Employee>();
            firstEmployeeMock.Object.TeamId = testEmployeesTeamIds[0];

            var secondEmployeeMock = new Mock<Employee>();
            secondEmployeeMock.Object.TeamId = testEmployeesTeamIds[1];

            var mockEmployees = new HashSet<Employee> { firstEmployeeMock.Object, secondEmployeeMock.Object };

            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            employeesDataWrapperMock.Setup(x => x.GetAll()).Returns(mockEmployees);

            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            IEnumerable<Employee> expectedEmployees = employeeService.EmployeesCollection
                .Where(x => x.TeamId == testEmployeesTeamIds[0]);

            // Act
            IEnumerable<Employee> actualEmployees = employeeService.GetEmployeesByTeamId(testEmployeesTeamIds[0]);

            // Assert
            CollectionAssert.AreEquivalent(expectedEmployees, actualEmployees);
        }
    }
}
