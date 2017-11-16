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
    public class GetEmployeesByLanguage_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenLanguageIsNotProvided()
        {
            // Arrange
            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeeService(employeesDataWrapperMock.Object).GetEmployeesByLanguage(null));
        }

        [Test]
        public void ReturnTheCorrectEmployee_WhenLanguageIsProvided()
        {
            // Arrange
            string[] testLanguageNames = new string[] { "test language 1", "test language 2" };

            var firstEmployeeMock = new Mock<Employee>();
            firstEmployeeMock.Object.Language = testLanguageNames[0];

            var secondEmployeeMock = new Mock<Employee>();
            secondEmployeeMock.Object.Language = testLanguageNames[1];

            var mockEmployees = new HashSet<Employee> { firstEmployeeMock.Object, secondEmployeeMock.Object };

            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            employeesDataWrapperMock.Setup(x => x.GetAll()).Returns(mockEmployees);

            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            IEnumerable<Employee> expectedEmployees = employeeService.EmployeesCollection
                .Where(x => x.Language.ToLower() == testLanguageNames[0]);

            // Act
            IEnumerable<Employee> actualEmployees = employeeService.GetEmployeesByLanguage(testLanguageNames[0]);

            // Assert
            CollectionAssert.AreEquivalent(expectedEmployees, actualEmployees);
        }
    }
}
