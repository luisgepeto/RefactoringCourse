using System;
namespace Refactoring
{
    public class CreditTransaction : Transaction
    {
        public CreditTransaction(bool isDebit, decimal amount) : base(isDebit, amount){}
        private string Recipient { get; set; }
        private string Sender { get; set; }
        public void SetRecipient(string recipient)
        {
            Recipient = recipient;
        }
        public string GetRecipient() { return Recipient; }
        public void SetSender(string sender)
        {
            Sender = sender;
        }
        public string GetSender()
        {
            return Sender;
        }
        public string GetSummary()
        {
            return String.Format("This is a credit transaction for ${0} from {1} to {2}", Amount, Sender, Recipient);
        }

        public decimal CalculateInterest(double rateOfInterest, int numberOfYears, InterestPeriod interestPeriodEnum)
        {
            var numberOfPeriodsPerYear = NumberOfPeriodsPerYear(interestPeriodEnum);
            return Math.Round((decimal)((double)Amount * Math.Pow(1 + rateOfInterest / numberOfPeriodsPerYear, numberOfPeriodsPerYear * numberOfYears)), 2);
        }

        private double NumberOfPeriodsPerYear(InterestPeriod interestPeriodEnum)
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
}