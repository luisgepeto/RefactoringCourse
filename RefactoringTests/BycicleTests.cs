﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class BycicleTests
    {
        [TestMethod]
        public void BycicleDriver_Move_SomeBike_ReturnsImMovingTire()
        {
            //Arrange
            var bycicle = new Bycicle("Some Bycicle Model");
            //Act
            var move = bycicle.Move();
            //Assert
            Assert.AreEqual("I am a moving tire", move, "The tire should be moving");
        }

        [TestMethod]
        public void BycicleDriver_Stop_SomeBike_ReturnsImMovingTire()
        {
            //Arrange
            var bycicle = new Bycicle("Some Bycicle Model");
            //Act
            var move = bycicle.Stop();
            //Assert
            Assert.AreEqual("I am a stopping tire", move, "The tire should be moving");
        }
    }
}
