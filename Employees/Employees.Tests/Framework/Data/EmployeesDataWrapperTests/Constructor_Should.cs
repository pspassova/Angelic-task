using Employees.DataModels.Models;
using Employees.Framework.Data;
using Employees.Framework.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Employees.Tests.Framework.Data.EmployeesDataWrapperTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDataProviderIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeesDataWrapper(null));
        }

        [Test]
        public void CreateAnInstanceOfEmployeesDataWrapper_WhenDataProviderIsProvided()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataProvider<Employee>>();

            // Act, Assert
            Assert.IsInstanceOf<EmployeesDataWrapper>(new EmployeesDataWrapper(dataProviderMock.Object));
        }
    }
}
