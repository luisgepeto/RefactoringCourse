using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring
{
    //large class
    public class Account
    {
        public Account(string accountHolderName, int accountNumber)
        {
            TransactionList = new List<Transaction>();
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
        }
        private int AccountNumber { get; set; }
        private string AccountHolderName { get; set; }
        private List<Transaction> TransactionList { get; set; }
        private decimal Balance { get; set; }
        private DateTime? LastTransactionDate { get; set; }

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

        public void Credit(decimal amount, string recipient)
        {
            Balance += amount;
            var creditTransaction = new CreditTransaction(false, amount);
            creditTransaction.SetRecipient(recipient);
            creditTransaction.SetSender(AccountHolderName);
            TransactionList.Add(creditTransaction);
            LastTransactionDate = DateTime.Now;
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

        private bool TryMakeCreditTransaction(MonthlyTransaction monthlyTransaction, string recipient)
        {
            var creditTransaction = new CreditTransaction(false, monthlyTransaction.TransactionValue);
            creditTransaction.SetRecipient(recipient);
            creditTransaction.SetSender(AccountHolderName);
            TransactionList.Add(creditTransaction);
            if (Balance > monthlyTransaction.MaxCreditAmount)
            {
                Balance -= monthlyTransaction.BaseMonthlyTotal;
                TransactionList.RemoveAt(TransactionList.Count - 1);
                return false;
            }
            return true;
        }
        
        public string SummaryCreditChargedMonthly(decimal totalAmount, string recipient, int numberOfMonths ,decimal maxCreditAmount, double rateOfInterest, int numberOfYears)
        {
            var monthlyTransaction = new MonthlyTransaction()
            {
                BaseMonthlyTotal = GetBaseMonthlyTotal(totalAmount, numberOfMonths),
                TransactionValue = GetBaseMonthlyTotal(totalAmount, numberOfMonths),
                MaxCreditAmount = maxCreditAmount
            };
            Balance += monthlyTransaction.BaseMonthlyTotal;
            if (!TryMakeCreditTransaction(monthlyTransaction, recipient))
                return "Your credit transaction was initially rejected because you reached your max balance";
            monthlyTransaction.TransactionValue = GetNextTransactionValue(rateOfInterest, numberOfYears, monthlyTransaction);
            Balance += monthlyTransaction.TransactionValue;
            if (!TryMakeCreditTransaction(monthlyTransaction, recipient)) 
                return "Your credit transaction was completely rejected because you reached your max balance";
            return "Your transaction was accepted";
        }

        private decimal GetNextTransactionValue(double rateOfInterest, int numberOfYears, MonthlyTransaction monthlyTransaction)
        {
            return new CreditTransaction(false, monthlyTransaction.BaseMonthlyTotal).CalculateInterest(rateOfInterest, numberOfYears, "Month");
        }
        
        private decimal GetBaseMonthlyTotal(decimal totalAmount, decimal numberOfMonths)
        {
            return totalAmount/numberOfMonths;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
        public DateTime? GetLastTransactionDate()
        {
            return LastTransactionDate;
        }
    }

    internal class MonthlyTransaction
    {
        public decimal TransactionValue { get; set; }
        public decimal BaseMonthlyTotal { get; set; }
        public decimal MaxCreditAmount { get; set; }

    }
}