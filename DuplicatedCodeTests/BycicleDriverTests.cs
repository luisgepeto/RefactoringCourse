using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class BycicleDriverTests
    {
        [TestMethod]
        public void BycicleDriver_GetBycicleModel_BMX_ReturnsBMX()
        {
            //Arrange
            var bycicleDriver = new BycicleDriver(DateTime.Now, 0, "LIC", DateTime.Now, "BMX");
            //Act
            var bycicleModel = bycicleDriver.GetBycicleModel();
            //Assert
            Assert.AreEqual("BMX", bycicleModel, "The bycicle model must be a BMX");
        }

        [TestMethod]
        public void BycicleDriver_Drive_SomeBike_ReturnsString()
        {
            //Arrange
            var bycicleDriver = new BycicleDriver(DateTime.Now, 0, "LIC", DateTime.Now, "BMX");
            //Act
            var driveOutput = bycicleDriver.Drive();
            //Assert
            Assert.AreEqual("I am driving a bike", driveOutput, "The vehicle driven must be a bike");
        }

        
    }
}



