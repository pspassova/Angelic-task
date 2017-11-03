using Employees.DataModels.Models;
using Employees.Framework.Providers;
using Employees.Framework.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Employees.Tests.Framework.Providers.DataFromFileProviderTests
{
    [TestFixture]
    public class GetDataFromJson_Should
    {
        private Mock<IFileReader> fileReaderMock;
        private Mock<IJsonConverter<IEnumerable<Employee>>> jsonConverterMock;
        private DataFromFileProvider<Employee> dataFromFileProvider;

        [SetUp]
        public void Setup()
        {
            this.fileReaderMock = new Mock<IFileReader>();
            this.jsonConverterMock = new Mock<IJsonConverter<IEnumerable<Employee>>>();
            this.dataFromFileProvider = new DataFromFileProvider<Employee>(fileReaderMock.Object, jsonConverterMock.Object);
        }

        [Test]
        public void InvokeReadMethodFromFileReader_WithTheCorrectPath()
        {
            // Arrange, Act
            this.dataFromFileProvider.GetDataFromJson();

            // Assert
            this.fileReaderMock.Verify(x => x.Read(It.IsAny<string>()), Times.Once);
        }
    }
}
