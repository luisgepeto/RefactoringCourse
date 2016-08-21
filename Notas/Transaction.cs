namespace Refactoring
{
    public class Transaction
    {
        public bool IsDebit { get; set; }
        public decimal Amount { get; set; }

        public Transaction(bool isDebit, decimal amount)
        {
            IsDebit = isDebit;
            Amount = amount;
        }
    }
}
