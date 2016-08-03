using System;

namespace Refactoring
{
    public class DebitTransaction : Transaction
    {
        public DebitTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
        //Duplicated code - Pull Up Field
        private string Recipient { get; set; }
        private string Sender { get; set; }
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
            //Duplicated code - Form Template
            return String.Format("This is a debit transaction for ${0} from {1} to {2}", Amount, Sender, Recipient);
        }

        public decimal CalculateInterest(double rateOfInterest, int numberOfYears, string interestPeriod)
        {
            //Duplicated code - Substitute Algorithm
            double numberOfPeriodsPerYear = 0;
            //Switch Statements - Try to add case - Replace with enum and make extension method
            switch (interestPeriod)
            {
                case "Day":
                    numberOfPeriodsPerYear = 365;
                    break;
                case "Month":
                    numberOfPeriodsPerYear = 12;
                    break;
                case "Semester":
                    numberOfPeriodsPerYear = 2;
                    break;
                case "Year":
                    numberOfPeriodsPerYear = 1;
                    break;
            }
            var initialAmount = (double)Amount;
            for (var i = 0; i < numberOfYears; i++)
            {
                var periodRate = rateOfInterest/numberOfPeriodsPerYear;
                for (var j = 0; j < numberOfPeriodsPerYear; j++)
                {
                    initialAmount += initialAmount*periodRate;
                }
            }
            return Math.Round((decimal)initialAmount, 2);
        }
    }
}
