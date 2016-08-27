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
    }
}
