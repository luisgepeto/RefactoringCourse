using System;

namespace DuplicatedCode
{
    public class CreditTransaction : Transaction
    {
        public CreditTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
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
            return String.Format("This is a credit transaction for ${0} from {1} to {2}", Amount, Sender, Recipient);
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
            return
                Math.Round(
                    (decimal)
                        ((double) Amount*
                         Math.Pow(1 + rateOfInterest/numberOfPeriodsPerYear, numberOfPeriodsPerYear*numberOfYears)), 2);
        }
    }
}
