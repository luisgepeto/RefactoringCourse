using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class StatementTests
    {
        private Account Account { get; set; }
        private MixedAccount MixedAccount { get; set; }
        private Statement Statement { get; set; }
        [TestInitialize]
        public void Setup()
        {
            MixedAccount = new MixedAccount("Account Holder Name", 999);
            Account = new Account("Account Holder Name", 999);
            Statement = new Statement(MixedAccount);
        }

        [TestMethod]
        public void Statement_GetTotalCreditBalance_NoTransactions_Returns0()
        {
            //Arrange
            //Act
            var totalCreditBalance = Statement.GetTotalCreditBalance();
            //Assert
            Assert.AreEqual(0, totalCreditBalance, "The total credit balance should be 100");
        }


        [TestMethod]
        public void Statement_GetTotalCreditBalance_AfterTransactions_Returns100()
        {
            //Arrange
            MixedAccount.Credit(50, "Some Recipient 1");
            MixedAccount.Debit(10, "Some Recipient 2");
            MixedAccount.Credit(50, "Some Recipient 3");
            MixedAccount.Debit(40, "Some Recipient 4");
            //Act
            var totalCreditBalance = Statement.GetTotalCreditBalance();
            //Assert
            Assert.AreEqual(100, totalCreditBalance, "The total credit balance should be 100");
        }


        [TestMethod]
        public void Statement_GetTotalDebitBalance_NoTransactions_Returns0()
        {
            //Arrange
            //Act
            var totalDebitBalance = Statement.GetTotalDebitBalance();
            //Assert
            Assert.AreEqual(0, totalDebitBalance, "The total credit balance should be 100");
        }


        [TestMethod]
        public void Statement_GetTotalDebitBalance_AfterTransactions_Returns50()
        {
            //Arrange
            MixedAccount.Credit(50, "Some Recipient 1");
            MixedAccount.Debit(10, "Some Recipient 2");
            MixedAccount.Credit(50, "Some Recipient 3");
            MixedAccount.Debit(40, "Some Recipient 4");
            //Act
            var totalDebitBalance = Statement.GetTotalDebitBalance();
            //Assert
            Assert.AreEqual(50, totalDebitBalance, "The total credit balance should be 50");
        }
    }
}
