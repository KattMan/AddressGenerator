using AddressGenerator.Services;
using AddressGeneratorInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DataGenerationTest
{
    [TestClass]
    [DeploymentItem("AddressGenerator")]
    public class AddressGeneratorTest
    {
        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateStreetNameTest()
        {
            //Arrange
            var expected = "Red Wood Lane";
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(o => o.GetAdjectives()).Returns(new List<string>() { "Red" });
            repositoryMock.Setup(o => o.GetNouns()).Returns(new List<string>() { "Wood" });
            repositoryMock.Setup(o => o.GetStreetTypes()).Returns(new List<string>() { "Lane" });

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateStreetName().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateCityTest()
        {
            //Arrange
            var expected = "City";
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(o => o.GetZipCodeInfo()).Returns(new List<string>() { "Zip, City, State, County" });

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateCity().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateCombinedZipInfoTest()
        {
            //Arrange
            var expected = "County\r\nCity, State Zip";
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(o => o.GetZipCodeInfo()).Returns(new List<string>() { "Zip, City, State, County" });

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateCombinedZipInfo().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateCountyTest()
        {
            //Arrange
            var expected = "County";
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(o => o.GetZipCodeInfo()).Returns(new List<string>() { "Zip, City, State, County" });

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateCounty().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateStateTest()
        {
            //Arrange
            var expected = "State";
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(o => o.GetZipCodeInfo()).Returns(new List<string>() { "Zip, City, State, County" });

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateState().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateStreetNumber()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository>();

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateStreetNumber().ToString();
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateSubNumberTest()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository>();

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateSubNumber().ToString();
            //Assert
            Assert.AreNotEqual(0, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateSubTypeTest()
        {
            //Arrange
            var expected = "Sub";
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(o => o.GetSubTypes()).Returns(new List<string>() { expected });

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateSubType().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Address Generator")]
        public void GenerateZipcodeTest()
        {
            //Arrange
            var expected = "Zip";
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(o => o.GetZipCodeInfo()).Returns(new List<string>() { "Zip, City, State, County" });

            var generator = new Generator(repositoryMock.Object);
            //Act
            var actual = generator.GenerateZipcode().ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
