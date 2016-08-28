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

        protected double NumberOfPeriodsPerYear(InterestPeriod interestPeriodEnum)
        {
            double numberOfPeriodsPerYear = 0;
            switch (interestPeriodEnum)
            {
                case InterestPeriod.Day:
                    numberOfPeriodsPerYear = 365;
                    break;
                case InterestPeriod.Month:
                    numberOfPeriodsPerYear = 12;
                    break;
                case InterestPeriod.Semester:
                    numberOfPeriodsPerYear = 2;
                    break;
                case InterestPeriod.Year:
                    numberOfPeriodsPerYear = 1;
                    break;
            }
            return numberOfPeriodsPerYear;
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
        //11. lazy class
        public string InvestmentPeriod { get; set; }
        public LongTermInvestmentTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
    }
}