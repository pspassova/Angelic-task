using Employees.Framework.Commands;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Providers.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Employees.Tests.Commands.DisplayEmployeesCommandTests
{
    [TestFixture]
    public class DisplayModifyEmloyeeTeamResult_Should
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
        public void InvokeModifyEmployeeTeamMethodFromEmployeeService_Once_WithCorrectParameters()
        {
            // Arrange, Act
            this.displayEmployeesCommand.DisplayModifyEmloyeeTeamResult(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            this.employeeServiceMock.Verify(x => x.ModifyEmployeeTeam(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }


        [Test]
        public void InvokeWriteLineMethodFromConsoleWriter_Once_WithTheCorrectMessages()
        {
            // Arrange
            string firstCorrectMessage = $"\n\r----Modify employee's team----";
            string secondCorrectMessage = $"\n\rEmployee with ID {It.IsAny<int>()} has changed it's team ID to {It.IsAny<int>()}";

            // Act
            this.displayEmployeesCommand.DisplayModifyEmloyeeTeamResult(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            this.consoleWriterMock.Verify(x => x.WriteLine(firstCorrectMessage), Times.Once);
            this.consoleWriterMock.Verify(x => x.WriteLine(secondCorrectMessage), Times.Once);
        }


        [Test]
        public void NotInvokeWriteLineMethodFromConsoleWriter_WhenUsingIncorrectMessage()
        {
            // Arrange
            string inCorrectMessage = "random incorrect message";

            // Act
            this.displayEmployeesCommand.DisplayModifyEmloyeeTeamResult(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(inCorrectMessage), Times.Never);
        }
    }
}
