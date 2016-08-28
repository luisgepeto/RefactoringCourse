using System;
namespace Refactoring
{
    public class CreditTransaction : Transaction
    {
        public CreditTransaction(bool isDebit, decimal amount) : base(isDebit, amount){}
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
            return GetBasicSummary("credit");
        }

        public decimal CalculateInterest(double rateOfInterest, int numberOfYears, InterestPeriod interestPeriodEnum)
        {
            return
                Math.Round(
                    (decimal)
                        ((double) Amount*
                         Math.Pow(1 + rateOfInterest/interestPeriodEnum.NumberOfPeriodsPerYear(),
                             interestPeriodEnum.NumberOfPeriodsPerYear()*numberOfYears)), 2);
        }
    }
}