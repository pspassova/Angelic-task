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
    public class CreateNewTeamId_Should
    {
        [Test]
        public void ReturnANewUniqueTeamId()
        {
            // Arrange
            int[] testEmployeesTeamIds = new int[] { 1, 5 };

            var firstEmployeeMock = new Mock<Employee>();
            firstEmployeeMock.Object.TeamId = testEmployeesTeamIds[0];

            var secondEmployeeMock = new Mock<Employee>();
            secondEmployeeMock.Object.TeamId = testEmployeesTeamIds[1];

            IEnumerable<Employee> mockEmployees = new List<Employee> { firstEmployeeMock.Object, secondEmployeeMock.Object };

            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            employeesDataWrapperMock.Setup(x => x.GetAll()).Returns(mockEmployees);

            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            // Act
            int resultTeamId = employeeService.CreateNewTeamId();
            bool resultTeamIdIsUnique = !testEmployeesTeamIds.Contains(resultTeamId);

            // Assert
            Assert.IsTrue(resultTeamIdIsUnique);
        }
    }
}
