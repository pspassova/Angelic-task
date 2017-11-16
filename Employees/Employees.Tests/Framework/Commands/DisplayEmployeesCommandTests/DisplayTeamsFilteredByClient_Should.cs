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
    public class DisplayTeamsFilteredByClient_Should
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
        public void ThrowArgumentNullException_WhenClientIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => this.displayEmployeesCommand.DisplayTeamsFilteredByClient(It.IsAny<string>()));
        }

        [Test]
        public void InvokeGetEmployeesByClientMethodFromEmployeeService_Once_WhenClientIsProvided()
        {
            // Arrange
            string testClient = "test client";

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByClient(testClient);

            // Assert
            this.employeeServiceMock.Verify(x => x.GetEmployeesByClient(testClient), Times.Once);
        }

        [Test]
        public void InvokeGroupEmployeesByTeamIdOrderedAscMethodFromEmployeeService_Once_WhenClientIsProvided()
        {
            // Arrange
            string testClient = "test Client";
            IEnumerable<Employee> testCollection = new HashSet<Employee>();

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByClient(testClient);

            // Assert
            this.employeeServiceMock.Verify(x => x.GroupEmployeesByTeamIdOrderedAsc(testCollection), Times.Once);
        }

        [Test]
        public void InvokeWriteLineMethodFromConsoleWriter_Once_WithTheCorrectMessage()
        {
            // Arrange
            string testClient = "test Client";
            string correctMessage = $"\n\r----Employees with client {testClient}----";

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByClient(testClient);

            // Assert
            this.consoleWriterMock.Verify(x => x.WriteLine(correctMessage), Times.Once);
        }


        [Test]
        public void NotInvokeWriteLineMethodFromConsoleWriter_WhenUsingIncorrectMessage()
        {
            // Arrange
            string testClient = "test Client";
            string inCorrectMessage = "random incorrect message";

            // Act
            this.displayEmployeesCommand.DisplayTeamsFilteredByClient(testClient);

            // Assert
            consoleWriterMock.Verify(x => x.WriteLine(inCorrectMessage), Times.Never);
        }
    }
}
