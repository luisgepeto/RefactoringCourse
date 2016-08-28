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

        public Transaction Credit(decimal amount, string recipient)
        {
            AddBalance(amount);
            var creditTransaction = new CreditTransaction(false, amount);
            creditTransaction.SetRecipient(recipient);
            creditTransaction.SetSender(AccountHolderName);
            PerformTransaction(creditTransaction);
            return creditTransaction;
        }
        public string SummaryCreditChargedMonthly(string recipient, decimal maxCreditAmount, InterestRate interestRate)
        {
            var monthlyTransaction = new MonthlyTransaction()
            {
                BaseMonthlyTotal = interestRate.GetBaseMonthlyTotal(),
                TransactionValue = interestRate.GetBaseMonthlyTotal(),
                MaxCreditAmount = maxCreditAmount
            };
            Balance += monthlyTransaction.BaseMonthlyTotal;
            if (!TryMakeCreditTransaction(monthlyTransaction, recipient))
                return "Your credit transaction was initially rejected because you reached your max balance";
            monthlyTransaction.TransactionValue = GetNextTransactionValue(interestRate.RateOfInterest, interestRate.NumberOfYears, monthlyTransaction);
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
            return new CreditTransaction(false, monthlyTransaction.BaseMonthlyTotal).CalculateInterest(rateOfInterest, numberOfYears, "Month", InterestPeriod.Month);
        }
        
    }
    internal class MonthlyTransaction
    {
        public decimal TransactionValue { get; set; }
        public decimal BaseMonthlyTotal { get; set; }
        public decimal MaxCreditAmount { get; set; }
    }
}
