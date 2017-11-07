using Employees.DataModels.Models;
using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Employees.Tests.Framework.Providers.Services.EmployeeServiceTests
{
    [TestFixture]
    public class GetEmployeeById_Should
    {
        [Test]
        public void InvokeGetByIdMethodFromEmployeesDataWrapper_Once()
        {
            // Arrange
            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            // Act
            employeeService.GetEmployeeById(It.IsAny<int>());

            // Assert
            employeesDataWrapperMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void ReturnTheCorrectEmployee_WhenEmployeeIdIsProvided()
        {
            // Arrange
            int[] testEmployeesIds = new int[] { 1, 5 };

            var firstEmployeeMock = new Mock<Employee>();
            firstEmployeeMock.Object.Id = testEmployeesIds[0];

            var secondEmployeeMock = new Mock<Employee>();
            secondEmployeeMock.Object.Id = testEmployeesIds[1];

            var mockEmployees = new List<Employee> { firstEmployeeMock.Object, secondEmployeeMock.Object };

            var employeesDataWrapperMock = new Mock<IEmployeesDataWrapper>();
            employeesDataWrapperMock.Setup(x => x.GetById(firstEmployeeMock.Object.Id))
                                    .Returns(firstEmployeeMock.Object);

            EmployeeService employeeService = new EmployeeService(employeesDataWrapperMock.Object);

            // Act
            Employee returnedEmployee = employeeService.GetEmployeeById(firstEmployeeMock.Object.Id);

            // Assert
            Assert.AreSame(firstEmployeeMock.Object, returnedEmployee);
        }
    }
}
