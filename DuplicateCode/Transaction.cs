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

        //Speculative Generality
        public void ScheduleTransaction(DateTime futureDate)
        {
            throw new NotImplementedException();
        }

    }
}
