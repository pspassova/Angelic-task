using Employees.DataModels.Models;
using Employees.Framework.Providers;
using Employees.Framework.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Employees.Tests.Framework.Providers.DataFromFileProviderTests
{
    [TestFixture]
    public class Constructor_Should
    {
        private Mock<IFileReader> fileReaderMock;
        private Mock<IJsonConverter<IEnumerable<Employee>>> jsonConverterMock;

        [SetUp]
        public void Setup()
        {
            this.fileReaderMock = new Mock<IFileReader>();
            this.jsonConverterMock = new Mock<IJsonConverter<IEnumerable<Employee>>>();
        }

        [Test]
        public void ThrowsArgumentNullException_WhenFileReaderIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new DataFromFileProvider<Employee>(null, this.jsonConverterMock.Object));
        }

        [Test]
        public void ThrowsArgumentNullException_WhenJsonConverterIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new DataFromFileProvider<Employee>(this.fileReaderMock.Object, null));
        }

        [Test]
        public void CreateAnInstanceOfDataFromFileProvider_WhenBothParametersAreProvided()
        {
            // Arrange, Act, Assert
            Assert.IsInstanceOf<DataFromFileProvider<Employee>>(new DataFromFileProvider<Employee>(this.fileReaderMock.Object, this.jsonConverterMock.Object));
        }
    }
}
