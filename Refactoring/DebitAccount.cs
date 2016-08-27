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
            Balance -= amount;
            var debitTransaction = new DebitTransaction(true, amount);
            debitTransaction.SetRecipient(recipient);
            debitTransaction.SetSender(AccountHolderName);
            TransactionList.Add(debitTransaction);
            LastTransactionDate = DateTime.Now;
        }
    }
}
