using Employees.Framework.Commands;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Providers.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace Employees.Tests.Framework.Commands.DisplayEmployeesCommandTests
{
    [TestFixture]
    public class DisplayEmployeesWithoutATeam_Should
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
        public void InvokeWriteLineMethodFromConsoleWriter_Once_WithTheCorrectMessage()
        {
            // Arrange
            string correctMessage = "\n\r----Employees with no team----";

            // Act
            this.displayEmployeesCommand.DisplayEmployeesWithoutATeam();

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(correctMessage), Times.Once);
        }

        [Test]
        public void NotInvokeWriteLineMethodFromConsoleWriter_WhenUsingIncorrectMessage()
        {
            // Arrange
            string inCorrectMessage = "random incorrect message";

            // Act
            this.displayEmployeesCommand.DisplayEmployeesWithoutATeam();

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(inCorrectMessage), Times.Never);
        }
    }
}
