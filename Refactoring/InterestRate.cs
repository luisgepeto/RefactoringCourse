namespace Refactoring
{
    public class InterestRate
    {
        public int NumberOfYears { get; set; }
        public double RateOfInterest { get; set; }
        public int NumberOfMonths { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GetBaseMonthlyTotal()
        {
            return TotalAmount / NumberOfMonths;
        }
    }
}
