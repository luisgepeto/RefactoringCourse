using System;

namespace Refactoring
{
    public class DebitAccount : Account
    {
        public DebitAccount(string accountHolderName, int accountNumber) : base(accountHolderName, accountNumber)
        {
        }

        public Transaction Debit(decimal amount, string recipient)
        {
            AddBalance(-amount);
            var debitTransaction = new DebitTransaction(true, amount);
            debitTransaction.SetRecipient(recipient);
            debitTransaction.SetSender(AccountHolderName);
            PerformTransaction(debitTransaction);
            return debitTransaction;
        }
    }
}
