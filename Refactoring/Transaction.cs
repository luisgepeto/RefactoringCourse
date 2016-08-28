using System;

namespace Refactoring
{
    public class Transaction
    {
        public bool IsDebit { get; private set; }
        public decimal Amount { get; private set; }
        protected string Recipient { get; set; }
        protected string Sender { get; set; }

        protected Transaction(bool isDebit, decimal amount)
        {
            IsDebit = isDebit;
            Amount = amount;
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

        protected string GetBasicSummary(string transactionType)
        {
            return String.Format("This is a {3} transaction for ${0} from {1} to {2}", Amount, Sender, Recipient, transactionType);
        }

        public decimal CalculateInterest(double rateOfInterest, int numberOfYears, InterestPeriod interestPeriodEnum)
        {
            return
                Math.Round(
                    (decimal)
                        ((double)Amount *
                         Math.Pow(1 + rateOfInterest / interestPeriodEnum.NumberOfPeriodsPerYear(),
                             interestPeriodEnum.NumberOfPeriodsPerYear() * numberOfYears)), 2);
        }
    }

    public class InvestmentTransaction : Transaction
    {
        public InvestmentTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
        public string InvestmentFundName { get; set; }

        public string GetSummary()
        {
            return String.Format("This is an investment transaction for ${0} in fund {1}", Amount, InvestmentFundName);
        }
    }
}