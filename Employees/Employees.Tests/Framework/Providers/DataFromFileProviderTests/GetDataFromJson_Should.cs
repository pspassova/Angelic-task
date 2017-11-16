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
        public void InvokeReadMethodFromFileReader_Once()
        {
            // Arrange, Act
            this.dataFromFileProvider.GetDataFromJson(It.IsAny<string>());

            // Assert
            this.fileReaderMock.Verify(x => x.Read(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void InvokeDeserializeObjectMethodFromJsonConverter_once()
        {
            // Arrange, Act
            this.dataFromFileProvider.GetDataFromJson(It.IsAny<string>());

            // Assert
            this.jsonConverterMock.Verify(x => x.DeserializeObject(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ReturnCorrectData_WhenPathToFileIsProvided()
        {
            // Arrange
            string testPathToFile = "../People.txt";
            string testFile = "{\"id\": 1, \"first_name\": \"Simmonds\"}";
            var expectedData = new HashSet<Employee>
            {
                new Mock<Employee>().Object,
                new Mock<Employee>().Object,
                new Mock<Employee>().Object
            };

            this.fileReaderMock.Setup(x => x.Read(testPathToFile)).Returns(testFile);
            this.jsonConverterMock.Setup(x => x.DeserializeObject(testFile)).Returns(expectedData);

            // Act
            IEnumerable<Employee> actualData = this.dataFromFileProvider.GetDataFromJson(testPathToFile);

            // Assert
            CollectionAssert.AreEquivalent(expectedData, actualData);
        }
    }
}
