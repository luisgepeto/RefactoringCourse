using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class CreditTransactionTests
    {
        [TestMethod]
        public void CreditTransaction_GetSender_DefaultSender_ReturnsNull()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 100);
            //Act
            //Assert
            Assert.IsNull(transaction.GetSender(), "Sender should be null before setting");
        }

        [TestMethod]
        public void CreditTransaction_GetSender_SenderHasName_ReturnsName()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 100);
            //Act
            var senderName = "Some Sender Name";
            transaction.SetSender(senderName);
            //Assert
            Assert.AreEqual(senderName, transaction.GetSender(), "Sender should be the expected one");
        }

        [TestMethod]
        public void CreditTransaction_GetRecipient_DefaultRecipient_ReturnsNull()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 100);
            //Act
            //Assert
            Assert.IsNull(transaction.GetRecipient(), "Recipient should be null before setting");
        }

        [TestMethod]
        public void CreditTransaction_GetRecipient_RecipientHasName_ReturnsName()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 100);
            //Act
            var recipientName = "Some Recipient Name";
            transaction.SetRecipient(recipientName);
            //Assert
            Assert.AreEqual(recipientName, transaction.GetRecipient(), "Recipient should be the expected one");
        }

        [TestMethod]
        public void CreditTransaction_GetSummary_SomeSenderAnotherRecipient_ReturnsSameMessage()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 100);
            //Act
            var recipientName = "Some Recipient";
            var senderName = "Some Sender";
            transaction.SetRecipient(recipientName);
            transaction.SetSender(senderName);
            //Assert
            Assert.AreEqual("This is a credit transaction for $100 from Some Sender to Some Recipient", transaction.GetSummary(), "Summary should be the expected one");
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void CreditTransaction_CalculateInterest_InvalidPeriod_ThrowsException()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 150);
            //Act
            var interest = transaction.CalculateInterest(0, 0, "Some Period", (InterestPeriod)9);
            //Assert
        }

        [TestMethod]
        public void CreditTransaction_CalculateInterest_3PercentRate10YearsDayPeriod_Returns20248()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 150);
            //Act
            var interest = transaction.CalculateInterest(0.03, 10, "Day", InterestPeriod.Day);
            //Assert
            Assert.AreEqual(202.48m, interest, "The amount with interest must equal the expected");
        }

        [TestMethod]
        public void CreditTransaction_CalculateInterest_3PercentRate10YearsMonthPeriod_Returns20240()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 150);
            //Act
            var interest = transaction.CalculateInterest(0.03, 10, "Month", InterestPeriod.Month);
            //Assert
            Assert.AreEqual(202.40m, interest, "The amount with interest must equal the expected");
        }

        [TestMethod]
        public void CreditTransaction_CalculateInterest_3PercentRate10YearsSemesterPeriod_Returns20203()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 150);
            //Act
            var interest = transaction.CalculateInterest(0.03, 10, "Semester", InterestPeriod.Semester);
            //Assert
            Assert.AreEqual(202.03m, interest, "The amount with interest must equal the expected");
        }

        [TestMethod]
        public void CreditTransaction_CalculateInterest_3PercentRate10YearsYearPeriod_Returns20159()
        {
            //Arrange
            var transaction = new CreditTransaction(false, 150);
            //Act
            var interest = transaction.CalculateInterest(0.03, 10, "Year", InterestPeriod.Year);
            //Assert
            Assert.AreEqual(201.59m, interest, "The amount with interest must equal the expected");
        }
    }
}
