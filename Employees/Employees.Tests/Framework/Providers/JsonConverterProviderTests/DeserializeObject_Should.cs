using Employees.DataModels.Models;
using Employees.Framework.Providers;
using Newtonsoft.Json;
using NUnit.Framework;
using System;

namespace Employees.Tests.Framework.Providers.JsonConverterProviderTests
{
    [TestFixture]
    public class DeserializeObject_Should
    {
        [Test]
        public void ThrowsArgumentNullException_WhenFileIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new JsonConverterProvider<Employee>().DeserializeObject(null));
        }

        [Test]
        public void ReturnCorrectData_WhenFileIsProvided()
        {
            // Arrange
            string testFile = "{\"id\": 1, \"first_name\": \"Simmonds\"}";

            Employee expectedData = JsonConvert.DeserializeObject<Employee>(testFile);

            JsonConverterProvider<Employee> jsonConverter = new JsonConverterProvider<Employee>();

            // Act
            Employee actualData = jsonConverter.DeserializeObject(testFile);

            // Assert
            Assert.AreEqual(expectedData.Id, actualData.Id);
            Assert.AreEqual(expectedData.FirstName, actualData.FirstName);
        }
    }
}
