using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class AccountTests
    {
        private Account Account { get; set; }
        private MixedAccount MixedAccount { get; set; }
        private DebitAccount DebitAccount { get; set; }
        private CreditAccount CreditAccount { get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            MixedAccount = new MixedAccount("My Account Holder Name", 9999);
            DebitAccount = new DebitAccount("My Account Holder Name", 9999);
            CreditAccount = new CreditAccount("My Account Holder Name", 9999);
        }

        [TestMethod]
        public void MixedAccount_GetLastTransaction_NoPreviousTransaction_ReturnsNull()
        {
            //Arrange
            //Act
            var lastTransaction = MixedAccount.GetLastTransaction();
            //Assert
            Assert.IsNull(lastTransaction, "The last transaction should not exist when initializing");
        }

        [TestMethod]
        public void CreditAccount_GetLastTransaction_PreviousCreditTransaction_ReturnsSame()
        {
            //Arrange
            CreditAccount.Credit(100, "Some Recipient");
            //Act
            var lastTransaction = CreditAccount.GetLastTransaction();
            //Assert
            Assert.IsNotNull(lastTransaction, "The last transaction should exist");
            Assert.AreEqual(100, lastTransaction.Amount, "The last transaction should have an amount of 100");
            Assert.IsFalse(lastTransaction.IsDebit, "The last transaction should be a credit type");
        }

        [TestMethod]
        public void DebitAccount_GetLastTransaction_PreviousDebitTransaction_ReturnsSame()
        {
            //Arrange
            DebitAccount.Debit(50, "Some Recipient");
            //Act
            var lastTransaction = DebitAccount.GetLastTransaction();
            //Assert
            Assert.IsNotNull(lastTransaction, "The last transaction should exist");
            Assert.AreEqual(50, lastTransaction.Amount, "The last transaction should have an amount of 50");
            Assert.IsTrue(lastTransaction.IsDebit, "The last transaction should be a debit type");
        }

        [TestMethod]
        public void MixedAccount_GetLastTransactionDate_BeforeTransaction_ReturnsNullDate()
        {
            //Arrange
            //Act
            var lastTransactionDate = MixedAccount.GetLastTransactionDate();
            //Assert
            Assert.IsNull(lastTransactionDate, "The last transaction date should not exist when initializing");
            Assert.IsFalse(lastTransactionDate.HasValue, "The last transaction date should not have a value");
        }


        [TestMethod]
        public void DebitAccount_GetLastTransactionDate_AfterTransaction_ReturnsTodaysDate()
        {
            //Arrange
            DebitAccount.Debit(10, "Some Recipient");
            //Act
            var lastTransactionDate = DebitAccount.GetLastTransactionDate();
            //Assert
            Assert.IsNotNull(lastTransactionDate, "The last transaction date should exist");
            Assert.AreEqual(DateTime.Now.Date, lastTransactionDate.Value.Date, "The last transaction should have an amount of 50");
        }

        [TestMethod]
        public void MixedAccount_GetBalance_AfterBiggerCreditTransaction_IsPositive()
        {
            //Arrange
            MixedAccount.Credit(100, "Some Recipient");
            MixedAccount.Debit(50, "Some Recipient");
            //Act
            var balance = MixedAccount.GetBalance();
            //Assert
            Assert.AreEqual(50, balance, "The balance should equal +50");
        }

        [TestMethod]
        public void MixedAccount_GetBalance_AfterBiggerDebitTransaction_IsNegative()
        {
            //Arrange
            MixedAccount.Debit(150, "Some Recipient");
            MixedAccount.Credit(50, "Some Recipient");
            //Act
            var balance = MixedAccount.GetBalance();
            //Assert
            Assert.AreEqual(-100, balance, "The balance should equal -100");
        }

        [TestMethod]
        public void CreditAccount_SummaryCreditChargedMonthly_150Dollars3PercentRate10YearsMonthPeriod10MaxAmount_IsRejected()
        {
            //Arrange
            //Act
            var result = CreditAccount.SummaryCreditChargedMonthly(150, "My Recipient", 5, 10, 0.03, 10, null);
            //Assert
            Assert.AreEqual("Your credit transaction was initially rejected because you reached your max balance", result, "The messages should match");
        }

        [TestMethod]
        public void CreditAccount_SummaryCreditChargedMonthly_150Dollars3PercentRate10YearsMonthPeriod50MaxAmount_IsRejected()
        {
            //Arrange
            //Act
            var result = CreditAccount.SummaryCreditChargedMonthly(150, "My Recipient", 5, 50, 0.03, 10, null);
            //Assert
            Assert.AreEqual("Your credit transaction was completely rejected because you reached your max balance", result, "The messages should match");
        }

        [TestMethod]
        public void CreditAccount_SummaryCreditChargedMonthly_150Dollars3PercentRate10YearsMonthPeriod100MaxAmount_IsAccepted()
        {
            //Arrange
            //Act
            var result = CreditAccount.SummaryCreditChargedMonthly(150, "My Recipient", 5, 100, 0.03, 10, null);
            //Assert
            Assert.AreEqual("Your transaction was accepted", result, "The messages should match");
        }

        [TestMethod]
        public void CreditAccount_GetNextBillingCycleStart_OneDayCycle_IsTomorrow()
        {
            //Arrange
            CreditAccount.BillingCycleDays = 1;
            CreditAccount.BillingCycleStartDate = new DateTime(DateTime.Now.Year, 1, 1);
            //Act
            var nextCycleDate = CreditAccount.GetNextBillingCycleStart();
            //Assert
            Assert.AreEqual(DateTime.Now.AddDays(1).Date, nextCycleDate, "the next cycle start should be today");
        }

        [TestMethod]
        public void CreditAccount_GetNextBillingCycleStart_30DayCycle_Matches()
        {
            //Arrange
            CreditAccount.BillingCycleDays = 30;
            CreditAccount.BillingCycleStartDate = new DateTime(DateTime.Now.Year, 1, 1);
            //Act
            var nextCycleDate = CreditAccount.GetNextBillingCycleStart();
            //Assert
            var expectedDate = new DateTime(DateTime.Now.Year, 1, 1).Date;
            while (expectedDate <= DateTime.Now.Date)
            {
                expectedDate = expectedDate.AddDays(30);
            }
            Assert.AreEqual(expectedDate, nextCycleDate, "the next cycle start should be the expected");
        }
    }
}