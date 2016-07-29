using System;
using DuplicatedCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DuplicatedCodeTests
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
    }
}
