using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class CarDriverTests
    {
        [TestMethod]
        public void CarDriver_GetCarBrand_Toyota_ReturnsToyota()
        {
            //Arrange
            var carDriver = new CarDriver(DateTime.Now, 0, "LIC",DateTime.Now, "Toyota");
            //Act
            var carBrand = carDriver.GetCarBrand();
            //Assert
            Assert.AreEqual("Toyota", carBrand, "The car brand must be a toyota");
        }

        [TestMethod]
        public void CarDriver_Drive_SomeCar_ReturnsString()
        {
            //Arrange
            var carDriver = new CarDriver(DateTime.Now, 0, "LIC", DateTime.Now, "Toyota");
            //Act
            var driveOutput = carDriver.Drive();
            //Assert
            Assert.AreEqual("I am driving a car", driveOutput, "The vehicle driven must be a car");
        }
    }
}
