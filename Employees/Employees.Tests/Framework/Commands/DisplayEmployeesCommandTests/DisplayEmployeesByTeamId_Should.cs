using Employees.Framework.Commands;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Providers.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Employees.Tests.Framework.Commands.DisplayEmployeesCommandTests
{
    [TestFixture]
    public class DisplayEmployeesByTeamId_Should
    {
        private Mock<IEmployeeService> employeeServiceMock;
        private Mock<IConsoleWriter> consoleWriterMock;
        private DisplayEmployeesCommand displayEmployeesCommand;

        [SetUp]
        public void Setup()
        {
            this.employeeServiceMock = new Mock<IEmployeeService>();
            this.consoleWriterMock = new Mock<IConsoleWriter>();
            this.displayEmployeesCommand = new DisplayEmployeesCommand(employeeServiceMock.Object, consoleWriterMock.Object);
        }

        [Test]
        public void ThrowArgumentException_WhenProvidedValueIsInvalid()
        {
            // Arrange
            int invalidTeamId = -5;

            // Act, Assert
            Assert.Throws<ArgumentException>(() => this.displayEmployeesCommand.DisplayEmployeesByTeamId(invalidTeamId));
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(5)]
        public void InvokeWriteLineMethodFromConsoleWriter_Once_WhenProvidedValueIsValid(int teamId)
        {
            // Arrange, Act
            this.displayEmployeesCommand.DisplayEmployeesByTeamId(teamId);

            // Assert
            this.consoleWriterMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void InvokeGetEmployeesByTeamIdFromEmployeeService_Once_WhenProvidedValueIsValid()
        {
            // Arrange
            int validTeamId = 5;

            // Act
            this.displayEmployeesCommand.DisplayEmployeesByTeamId(validTeamId);

            // Assert
            this.employeeServiceMock.Verify(x => x.GetEmployeesByTeamId(validTeamId), Times.Once);
        }
    }
}
