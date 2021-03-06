﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class LongTermInvestmentTransactionTests
    {
        [TestMethod]
        public void InvestmentTransaction_GetSummary_50_ReturnsText()
        {
            //Arrange
            var investmentTransaction = new LongTermInvestmentTransaction(false, 50);
            //Act
            var output = investmentTransaction.GetSummary();

            //Assert
            Assert.AreEqual("This is an investment transaction for $50 in fund ", output, "The get summary message should match");

        }
    }
}
