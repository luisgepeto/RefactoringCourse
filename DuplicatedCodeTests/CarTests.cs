using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void Car_VerifyOwnership_NoOwner_NoOwnerString()
        {
            //Arrange
            var car = new Car("Some Brand");
            //Act
            var ownership = car.VerifyOwnership();
            //Assert
            Assert.AreEqual("This car has no owner", ownership, "no owner should have been set");
        }

        [TestMethod]
        public void Car_VerifyOwnership_OwnerNoAddress_OwnerNoAddressString()
        {
            //Arrange
            var car = new Car("Some Brand");
            var driver = new CarDriver(DateTime.Now, 5, "1", DateTime.Now, "Brand");
            car.SetDriver(driver);
            //Act
            var ownership = car.VerifyOwnership();
            //Assert
            Assert.AreEqual("This car has an owner", ownership, "an owner should have been set");
        }


        [TestMethod]
        public void Car_VerifyOwnership_OwnerAddress_OwnerAddressString()
        {
            //Arrange
            var car = new Car("Some Brand");
            var driver = new CarDriver(DateTime.Now, 5, "1", DateTime.Now, "Brand");
            driver.AddressLine1 = "My Address";
            car.SetDriver(driver);
            //Act
            var ownership = car.VerifyOwnership();
            //Assert
            Assert.AreEqual("This car has an owner\nThe owner's address is:\nMy Address", ownership, "an owner should have been set");
        }
    }
}
