using System;
using System.Collections.Generic;
using System.Linq;

namespace DuplicatedCode
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
        private string AccountHolderName { get; set; }
        private List<Transaction> TransactionList { get; set; }
        private decimal Balance { get; set; }
        private DateTime? LastTransactionDate { get; set; }
        //Large class - Extract subclass/class
        //Data Clumps - extract class
        public decimal MaxCreditAmount { get; set; }
        public DateTime BillingCycleStartDate { get; set; }
        public int BillingCycleDays { get; set; }

        public DateTime GetNextBillingCycleStart()
        {
            var currentDate = DateTime.Now.Date;
            var iteratingDate = BillingCycleStartDate.Date;
            while (iteratingDate <= currentDate)
            {
                iteratingDate = iteratingDate.AddDays(BillingCycleDays);
            }
            return iteratingDate;
        }

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
            //Duplicated code - Extract method
            Balance += amount;
            var creditTransaction = new CreditTransaction(false, amount);
            creditTransaction.SetRecipient(recipient);
            creditTransaction.SetSender(AccountHolderName);
            TransactionList.Add(creditTransaction);
            LastTransactionDate = DateTime.Now;
        }

        public void Debit(decimal amount, string recipient)
        {
            //Duplicated code- Extract method
            Balance -= amount;
            var debitTransaction = new DebitTransaction(true, amount);
            debitTransaction.SetRecipient(recipient);
            debitTransaction.SetSender(AccountHolderName);
            TransactionList.Add(debitTransaction);
            LastTransactionDate = DateTime.Now;
        }

        //Long Method - Introduce parameter object, Preserve Whole Object
        //Long parameter list - Replace Parameter with Method
        //Data Clumps - extract class
        public string SummaryCreditChargedMonthly(decimal totalAmount, string recipient, int numberOfMonths ,decimal maxCreditAmount, double rateOfInterest, int numberOfYears)
        {
            //Long Method - Replace Temp With Query
            var baseMonthlyTotal = totalAmount/numberOfMonths;
            Balance += baseMonthlyTotal;
            var creditTransaction = new CreditTransaction(false, baseMonthlyTotal);
            creditTransaction.SetRecipient(recipient);
            creditTransaction.SetSender(AccountHolderName);
            TransactionList.Add(creditTransaction);
            if (Balance > maxCreditAmount)
            {
                //Long Method - Extract Method
                Balance -= baseMonthlyTotal;
                TransactionList.RemoveAt(TransactionList.Count-1);
                return "Your credit transaction was initially rejected because you reached your max balance";
            }
            var nextCreditTransactionValue = new CreditTransaction(false, baseMonthlyTotal).CalculateInterest(rateOfInterest, numberOfYears, "Month");
            Balance += nextCreditTransactionValue;
            var nextCreditTransaction = new CreditTransaction(false, nextCreditTransactionValue);
            nextCreditTransaction.SetRecipient(recipient);
            nextCreditTransaction.SetSender(AccountHolderName);
            TransactionList.Add(nextCreditTransaction);
            if (Balance > maxCreditAmount)
            {
                //Long Method - Extract Method
                Balance -= baseMonthlyTotal;
                TransactionList.RemoveAt(TransactionList.Count - 1);
                return "Your credit transaction was completely rejected because you reached your max balance";
            }
            return "Your transaction was accepted";
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
}
