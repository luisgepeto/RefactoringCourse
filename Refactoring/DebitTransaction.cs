using System;

namespace Refactoring
{
    public class DebitTransaction : Transaction
    {
        public DebitTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
        public void SetRecipient(string recipient)
        {
            Recipient = recipient;
        }
        public string GetRecipient()
        {
            return Recipient;
        }
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
            return GetBasicSummary("debit");
        }

        public decimal CalculateInterest(double rateOfInterest, int numberOfYears, InterestPeriod interestPeriodEnum)
        {
            var initialAmount = (double)Amount;
            for (var i = 0; i < numberOfYears; i++)
            {
                var periodRate = rateOfInterest/ interestPeriodEnum.NumberOfPeriodsPerYear();
                for (var j = 0; j < interestPeriodEnum.NumberOfPeriodsPerYear(); j++)
                {
                    initialAmount += initialAmount*periodRate;
                }
            }
            return Math.Round((decimal)initialAmount, 2);
        }
    }
}