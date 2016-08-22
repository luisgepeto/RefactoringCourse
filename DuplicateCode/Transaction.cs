using System;

namespace Refactoring
{
    public class Transaction
    {
        public bool IsDebit { get; private set; }
        public decimal Amount { get; private set; }

        protected Transaction(bool isDebit, decimal amount)
        {
            IsDebit = isDebit;
            Amount = amount;
        }
        public void ScheduleTransaction(DateTime futureDate)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class InvestmentTransaction : Transaction
    {
        protected InvestmentTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
        public string InvestmentFundName { get; set; }

        public string GetSummary()
        {
            return String.Format("This is an investment transaction for ${0} in fund {1}", Amount, InvestmentFundName);
        }
    }

    public class LongTermInvestmentTransaction : InvestmentTransaction
    {
        public string InvestmentPeriod { get; set; }
        public LongTermInvestmentTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
    }
}