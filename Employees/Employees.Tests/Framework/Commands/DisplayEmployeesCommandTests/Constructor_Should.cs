using Employees.Framework.Commands;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Providers.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Employees.Tests.Framework.Commands.DisplayEmployeesCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenEmployeesSeriviceIsNotProvided()
        {
            // Arrange
            var consoleWriterMock = new Mock<IConsoleWriter>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new DisplayEmployeesCommand(null, consoleWriterMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenConsoleWriterIsNotProvided()
        {
            // Arrange
            var employeeServiceMock = new Mock<IEmployeeService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new DisplayEmployeesCommand(employeeServiceMock.Object, null));
        }

        [Test]
        public void CreateAnInstanceOfDisplayEmployeesCommand_WhenBothParametersAreProvided()
        {
            // Arrange
            var employeeServiceMock = new Mock<IEmployeeService>();
            var consoleWriterMock = new Mock<IConsoleWriter>();

            // Act, Assert
            Assert.IsInstanceOf<DisplayEmployeesCommand>(new DisplayEmployeesCommand(employeeServiceMock.Object, consoleWriterMock.Object));
        }
    }
}
