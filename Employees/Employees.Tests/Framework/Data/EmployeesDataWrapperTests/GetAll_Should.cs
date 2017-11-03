using Employees.DataModels.Models;
using Employees.Framework.Data;
using Employees.Framework.Providers.Contracts;
using Moq;
using NUnit.Framework;

namespace Employees.Tests.Framework.Data.EmployeesDataWrapperTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void InvokeGetDataFromJsonMethodFromDataProvider_Once()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataProvider<Employee>>();
            var employeesDataWrapper = new EmployeesDataWrapper(dataProviderMock.Object);

            // Act
            employeesDataWrapper.GetAll();

            // Assert
            dataProviderMock.Verify(x => x.GetDataFromJson(), Times.Once);
        }
    }
}
