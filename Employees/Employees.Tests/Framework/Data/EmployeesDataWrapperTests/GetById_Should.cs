using Employees.DataModels.Models;
using Employees.Framework.Data;
using Employees.Framework.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Tests.Framework.Data.EmployeesDataWrapperTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnTheCorrectEmployee()
        {
            // Arrange
            int testEmployeeId = 5;

            var employeeMock = new Mock<Employee>();
            employeeMock.Object.Id = testEmployeeId;

            var testEmployeesList = new List<Employee> {
                employeeMock.Object,
                new Mock<Employee>().Object,
                new Mock<Employee>().Object
            };

            var dataProviderMock = new Mock<IDataProvider<Employee>>();
            dataProviderMock.Setup(x => x.GetDataFromJson(It.IsAny<string>())).Returns(testEmployeesList);
            var employeesDataWrapper = new EmployeesDataWrapper(dataProviderMock.Object);

            var expectedEmployee = testEmployeesList.SingleOrDefault(x => x.Id == testEmployeeId);

            // Act
            var actualEmployee = employeesDataWrapper.GetById(testEmployeeId);

            // Assert
            Assert.AreSame(expectedEmployee, actualEmployee);
        }
    }
}
