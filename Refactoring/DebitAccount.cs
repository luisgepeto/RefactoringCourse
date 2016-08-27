using System;

namespace Refactoring
{
    public class DebitAccount : Account
    {
        public DebitAccount(string accountHolderName, int accountNumber) : base(accountHolderName, accountNumber)
        {
        }

        public void Debit(decimal amount, string recipient)
        {
            AddBalance(-amount);
            var debitTransaction = new DebitTransaction(true, amount);
            debitTransaction.SetRecipient(recipient);
            debitTransaction.SetSender(AccountHolderName);
            PerformTransaction(debitTransaction);
        }

        private void AddBalance(decimal amount)
        {
            Balance += amount;
        }

        private void PerformTransaction(Transaction creditTransaction)
        {
            TransactionList.Add(creditTransaction);
            LastTransactionDate = DateTime.Now;
        }
    }
}
