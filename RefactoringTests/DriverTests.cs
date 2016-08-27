using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class DriverTests
    {
        [TestMethod]
        public void Driver_GetPointsOnLicense_SetTo5_Returns5()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 5, "LICENSENUMBER", DateTime.Now);
            //Act
            var pointsOnLicense = driver.GetPointsOnLicense();
            //Assert
            Assert.AreEqual(5, pointsOnLicense, "The number of license points should be 5");
        }

        [TestMethod]
        public void Driver_IsLicenseValid_SetTo5_ReturnsFalse()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 5, "LICENSENUMBER", DateTime.Now);
            //Act
            var isLicenseValid = driver.IsLicenseValid();
            //Assert
            Assert.IsFalse(isLicenseValid, "The license should not be valid");
        }

        [TestMethod]
        public void Driver_IsLicenseValid_SetTo4_ReturnsTrue()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 4, "LICENSENUMBER", DateTime.Now);
            //Act
            var isLicenseValid = driver.IsLicenseValid();
            //Assert
            Assert.IsTrue(isLicenseValid, "The license should be valid");
        }

        [TestMethod]
        public void Driver_GenerateLicenseReport_NumberLIC0001POINTS2_ReturnsExpected()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 2, "LIC0001", new DateTime(2017, 1, 1));
            //Act
            var licenseReport = driver.GenerateLicenseReport();
            //Assert
            Assert.AreEqual("Your license number is LIC0001 and you have 2 points in your license. Your license expires on 1/1/2017", licenseReport, "The license report should match the expected");
        }

        [TestMethod]
        public void Driver_GetAge_BornOn1980_Returns36()
        {
            //Arrange
            var driver = new Driver(new DateTime(1980, 1, 1), 2, "LIC0001", DateTime.Now);
            //Act
            var age = driver.GetAge();
            //Assert
            Assert.AreEqual(36, age, "The license report should match the expected");
        }

        [TestMethod]
        public void Driver_FormattedAddress_CompleteAddress_ReturnsExpected()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 0, "LIC0001", DateTime.Now);
            driver.Address.AddressLine1 = "Address Line 1";
            driver.AddressLine2 = "Address Line 2";
            driver.City = "City";
            driver.State = "State";
            driver.Zip = "123456";
            //Act
            var formattedAddress = driver.FormattedAddress();
            //Assert
            Assert.AreEqual("Address Line 1\nAddress Line 2\nCity, State\n12345", formattedAddress, "The license report should match the expected");
        }
    }
}
