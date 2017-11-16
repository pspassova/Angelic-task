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
    public class GroupEmployeesByTeamIdOrderedAsc_Should
    {
        [Test]
        public void ReturnEmployeesGroupedByTeamId()
        {
            // Arrange
            int[] testEmployeesTeamIds = new int[] { 1, 5 };

            var firstEmployeeMock = new Mock<Employee>();
            firstEmployeeMock.Object.TeamId = testEmployeesTeamIds[0];

            var secondEmployeeMock = new Mock<Employee>();
            secondEmployeeMock.Object.TeamId = testEmployeesTeamIds[1];

            var thirdEmployeeMock = new Mock<Employee>();
            thirdEmployeeMock.Object.TeamId = testEmployeesTeamIds[1];

            var mockEmployees = new HashSet<Employee>
            {
                firstEmployeeMock.Object,
                secondEmployeeMock.Object,
                thirdEmployeeMock.Object
            };

            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            // Act
            IDictionary<int, HashSet<Employee>> resultEmployeesGroups = employeeService.GroupEmployeesByTeamIdOrderedAsc(mockEmployees);

            // Assert
            Assert.AreEqual(testEmployeesTeamIds, resultEmployeesGroups.Keys);

            CollectionAssert.AreEquivalent(mockEmployees.Where(x => x.TeamId == testEmployeesTeamIds[0]),
                                            resultEmployeesGroups[testEmployeesTeamIds[0]]);
            CollectionAssert.AreEquivalent(mockEmployees.Where(x => x.TeamId == testEmployeesTeamIds[1]),
                                resultEmployeesGroups[testEmployeesTeamIds[1]]);
        }
    }
}
