namespace Refactoring
{
    public class LongTermInvestmentTransaction : InvestmentTransaction
    {

        //Lazy class - collapse hierarchy
        public string InvestmentPeriod { get; set; }

        public LongTermInvestmentTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
    }
}
