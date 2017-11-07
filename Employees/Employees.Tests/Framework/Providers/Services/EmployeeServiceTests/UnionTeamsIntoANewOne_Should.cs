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
    public class UnionTeamsIntoANewOne_Should
    {
        [Test]
        public void SetEmployeesTeamsIdsToANewOne()
        {
            // Arrange
            int[] testEmployeesTeamIds = new int[] { 1, 5 };
            int[] testEmployeesIds = new int[] { 10, 15 };

            var firstEmployeeMock = new Mock<Employee>();
            firstEmployeeMock.Object.TeamId = testEmployeesTeamIds[0];
            firstEmployeeMock.Object.Id = testEmployeesIds[0];

            var secondEmployeeMock = new Mock<Employee>();
            secondEmployeeMock.Object.TeamId = testEmployeesTeamIds[1];
            secondEmployeeMock.Object.Id = testEmployeesIds[1];

            IEnumerable<Employee> mockEmployees = new List<Employee> { firstEmployeeMock.Object, secondEmployeeMock.Object };

            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            employeesDataWrapperMock.Setup(x => x.GetAll()).Returns(mockEmployees);

            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            // Act
            int newTeamId = 0;
            employeeService.UnionTeamsIntoANewOne(testEmployeesTeamIds, newTeamId);

            bool employeesWithOldTeamIdStillExist = employeeService.EmployeesCollection
                .Select(x => x.TeamId)
                .Contains(testEmployeesTeamIds[0]) || employeeService.EmployeesCollection
                .Select(x => x.TeamId)
                .Contains(testEmployeesTeamIds[1]);

            bool employeesHaveANewTeamId = employeeService.EmployeesCollection.Select(x => x.TeamId == newTeamId).Count() == mockEmployees.Count();

            // Assert
            Assert.IsFalse(employeesWithOldTeamIdStillExist);
            Assert.IsTrue(employeesHaveANewTeamId);
        }
    }
}
