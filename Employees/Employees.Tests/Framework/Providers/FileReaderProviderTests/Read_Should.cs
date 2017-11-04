using Employees.Framework.Providers;
using Moq;
using NUnit.Framework;
using System;
using System.IO;

namespace Employees.Tests.Framework.Providers.FileReaderProviderTests
{
    [TestFixture]
    public class Read_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPathToFileIsNotProvided()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new FileReaderProvider().Read(null));
        }

        [Test]
        public void ReturnCorrectFile_WhenPathToFileIsProvided()
        {
            // Arrange
            string testPathToFile = AppDomain.CurrentDomain.BaseDirectory + "../../TestJsonData/People.txt";
            string expectedFile = this.ReadFileWithStreamReader(testPathToFile);

            FileReaderProvider fileReader = new FileReaderProvider();

            // Act
            string actualFile = fileReader.Read(testPathToFile);

            // Assert
            Assert.AreEqual(expectedFile, actualFile);
        }

        private string ReadFileWithStreamReader(string pathToFile)
        {
            string file = null;

            using (StreamReader streamReader = new StreamReader(pathToFile))
            {
                file = streamReader.ReadToEnd();
            }

            return file;
        }
    }
}
