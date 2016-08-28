using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring
{
    public abstract class Account
    {
        protected Account(string accountHolderName, int accountNumber)
        {
            TransactionList = new List<Transaction>();
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
        }
        private int AccountNumber { get; set; }
        protected string AccountHolderName { get; set; }
        protected List<Transaction> TransactionList { get; set; }
        protected decimal Balance { get; set; }
        protected DateTime? LastTransactionDate { get; set; }
        
        public Transaction GetLastTransaction()
        {
            return TransactionList.LastOrDefault();
        }

        public Transaction GetTransactionAt(int index)
        {
            return TransactionList.ElementAtOrDefault(index);
        }

        public decimal GetTransactionAmountIfCreditAt(int index)
        {
            var transaction =  GetTransactionAt(index);
            if (transaction is CreditTransaction) return transaction.Amount;
            return 0;
        }

        public decimal GetTransactionAmountIfDebitAt(int index)
        {
            var transaction = GetTransactionAt(index);
            if (transaction is DebitTransaction) return transaction.Amount;
            return 0;
        }

        public int GetTransactionCount()
        {
            return TransactionList.Count;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
        public DateTime? GetLastTransactionDate()
        {
            return LastTransactionDate;
        }
        protected void AddBalance(decimal amount)
        {
            Balance += amount;
        }

        protected void PerformTransaction(Transaction creditTransaction)
        {
            TransactionList.Add(creditTransaction);
            LastTransactionDate = DateTime.Now;
        }
    }
}