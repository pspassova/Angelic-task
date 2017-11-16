using Employees.DataModels.Models;
using Employees.Framework.Commands;
using Employees.Framework.Providers.Contracts;
using Employees.Framework.Providers.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Employees.Tests.Framework.Commands.DisplayEmployeesCommandTests
{
    [TestFixture]
    public class DisplayTeamsFilteredByLanguage_Should
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
        public void ThrowArgumentNullException_WhenLanguageIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => this.displayEmployeesCommand.DisplayTeamsFilteredByLanguage(It.IsAny<string>()));
        }
        
        [Test]
        public void InvokeGetEmployeesByLanguageMethodFromEmployeeService_Once_WhenLanguageIsProvided()
        {
            // Arrange
            string testLanguage = "test language";

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByLanguage(testLanguage);

            // Assert
            this.employeeServiceMock.Verify(x => x.GetEmployeesByLanguage(testLanguage), Times.Once);
        }

        [Test]
        public void InvokeGroupEmployeesByTeamIdOrderedAscMethodFromEmployeeService_Once_WhenLanguageIsProvided()
        {
            // Arrange
            string testLanguage = "test language";
            IEnumerable<Employee> testCollection = new HashSet<Employee>();

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByLanguage(testLanguage);

            // Assert
            this.employeeServiceMock.Verify(x => x.GroupEmployeesByTeamIdOrderedAsc(testCollection), Times.Once);
        }

        [Test]
        public void InvokeWriteLineMethodFromConsoleWriter_Once_WithTheCorrectMessage()
        {
            // Arrange
            string testLanguage = "test language";
            string correctMessage = $"\n\r----Employees who speak {testLanguage}----";

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByLanguage(testLanguage);

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(correctMessage), Times.Once);
        }

        [Test]
        public void NotInvokeWriteLineMethodFromConsoleWriter_WhenUsingIncorrectMessage()
        {
            // Arrange
            string testLanguage = "test language";
            string inCorrectMessage = "random incorrect message";

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByLanguage(testLanguage);

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(inCorrectMessage), Times.Never);
        }
    }
}
