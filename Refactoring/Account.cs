using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring
{
    public class Account
    {
        public Account(string accountHolderName, int accountNumber)
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