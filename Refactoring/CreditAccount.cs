using System;

namespace Refactoring
{
    public class CreditAccount : Account
    {
        public CreditAccount(string accountHolderName, int accountNumber): base(accountHolderName, accountNumber)
        {
            
        }

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

        public void Credit(decimal amount, string recipient)
        {
            Balance += amount;
            var creditTransaction = new CreditTransaction(false, amount);
            creditTransaction.SetRecipient(recipient);
            creditTransaction.SetSender(AccountHolderName);
            TransactionList.Add(creditTransaction);
            LastTransactionDate = DateTime.Now;
        }

        public string SummaryCreditChargedMonthly(decimal totalAmount, string recipient, int numberOfMonths, decimal maxCreditAmount, double rateOfInterest, int numberOfYears)
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
        private decimal GetNextTransactionValue(double rateOfInterest, int numberOfYears, MonthlyTransaction monthlyTransaction)
        {
            return new CreditTransaction(false, monthlyTransaction.BaseMonthlyTotal).CalculateInterest(rateOfInterest, numberOfYears, "Month");
        }

        private decimal GetBaseMonthlyTotal(decimal totalAmount, decimal numberOfMonths)
        {
            return totalAmount / numberOfMonths;
        }
    }
    internal class MonthlyTransaction
    {
        public decimal TransactionValue { get; set; }
        public decimal BaseMonthlyTotal { get; set; }
        public decimal MaxCreditAmount { get; set; }
    }
}
