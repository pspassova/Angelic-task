using Employees.Framework.Commands;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Providers.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace Employees.Tests.Commands.DisplayEmployeesCommandTests
{
    [TestFixture]
    public class DisplayUnionTeamsResult_Should
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
        public void InvokeCreateNewTeamIdMethodFromEmployeeService_Once()
        {
            // Arrange
            int[] testTeamsIds = new int[] { 1, 5 };

            // Act
            this.displayEmployeesCommand.DisplayUnionTeamsResult(testTeamsIds);

            // Assert
            this.employeeServiceMock.Verify(x => x.CreateNewTeamId(), Times.Once);
        }

        [Test]
        public void InvokeUnionTeamsIntoANewOneMethodFromEmployeeService_Once()
        {
            // Arrange
            int[] testTeamsIds = new int[] { 1, 5 };

            // Act
            this.displayEmployeesCommand.DisplayUnionTeamsResult(testTeamsIds);

            // Assert
            this.employeeServiceMock.Verify(x => x.UnionTeamsIntoANewOne(testTeamsIds, It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void InvokeWriteLineMethodFromConsoleWriter_Once_WithTheCorrectMessage()
        {
            // Arrange
            int[] testTeamsIds = new int[] { 1, 5 };
            string correctMessage = $"\n\r---Union teams with team IDs {String.Join(", ", testTeamsIds)} into a new one----";

            // Act
            this.displayEmployeesCommand.DisplayUnionTeamsResult(testTeamsIds);

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(correctMessage), Times.Once);
        }

        [Test]
        public void NotInvokeWriteLineMethodFromConsoleWriter_WhenUsingIncorrectMessage()
        {
            // Arrange
            int[] testTeamsIds = new int[] { 1, 5 };
            string inCorrectMessage = "random incorrect message";

            // Act
            this.displayEmployeesCommand.DisplayUnionTeamsResult(testTeamsIds);

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(inCorrectMessage), Times.Never);
        }
    }
}
