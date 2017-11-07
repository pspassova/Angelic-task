using Employees.DataModels.Models;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Tests.Framework.Providers.Services.EmployeeServiceTests
{
    [TestFixture]
    public class GetEmployeesByClient_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenClientIsNotProvided()
        {
            // Arrange
            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeeService(employeesDataWrapperMock.Object).GetEmployeesByClient(null));
        }

        [Test]
        public void ReturnTheCorrectEmployee_WhenClientIsProvided()
        {
            // Arrange
            string[] testClientNames = new string[] { "test client 1", "test client 2" };

            var firstEmployeeMock = new Mock<Employee>();
            firstEmployeeMock.Object.Client = testClientNames[0];

            var secondEmployeeMock = new Mock<Employee>();
            secondEmployeeMock.Object.Client = testClientNames[1];

            var mockEmployees = new List<Employee> { firstEmployeeMock.Object, secondEmployeeMock.Object };

            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            employeesDataWrapperMock.Setup(x => x.GetAll()).Returns(mockEmployees);

            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            IEnumerable<Employee> expectedEmployees = employeeService.EmployeesCollection
                .Where(x => x.Client.ToLower() == testClientNames[0]);

            // Act
            IEnumerable<Employee> actualEmployees = employeeService.GetEmployeesByClient(testClientNames[0]);

            // Assert
            CollectionAssert.AreEquivalent(expectedEmployees, actualEmployees);
        }
    }
}
