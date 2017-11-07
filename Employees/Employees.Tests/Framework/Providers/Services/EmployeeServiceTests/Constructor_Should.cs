using Employees.Framework.Data.Contracts;
using Employees.Framework.Providers.Services;
using Moq;
using NUnit.Framework;
using System;

namespace Employees.Tests.Framework.Providers.Services.EmployeeServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenEmployeesDataWrapperIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeeService(null));
        }

        [Test]
        public void CreateAnInstanceOfEmployeeService_WhenEmployeesDataWrapperIsProvided()
        {
            // Arrange
            var dataWrapperMock = new Mock<IEmployeesDataWrapper>();

            // Act, Assert
            Assert.IsInstanceOf<EmployeeService>(new EmployeeService(dataWrapperMock.Object));
        }
    }
}
