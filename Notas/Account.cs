using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring
{
    public class Account
    {
        public Account()
        {
            TransactionList = new List<Transaction>();
        }

        private List<Transaction> TransactionList { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastTransactionDate { get; set; }

        public Transaction GetLastTransaction()
        {
            return TransactionList.Last();
        }

        public void Credit(decimal amount)
        {
            Balance += amount;
            TransactionList.Add(new Transaction(false, amount));
            LastTransactionDate = DateTime.Now;
        }

        public void Debit(decimal amount)
        {
            Balance -= amount;
            TransactionList.Add(new Transaction(true, amount));
            LastTransactionDate = DateTime.Now;
        }
    }
}
