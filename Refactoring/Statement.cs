namespace Refactoring
{
    public class Statement
    {
        private Account Account { get; set; }
        public Statement(Account account)
        {
            Account = account;
        }
        
        public decimal GetTotalCreditBalance()
        {
            var totalCreditBalance = 0m;
            var totalTransactions = Account.GetTransactionCount();
            for (var i = 0; i < totalTransactions; i++)
            {
                totalCreditBalance += Account.GetTransactionAmountIfCreditAt(i);
            }
            return totalCreditBalance;
        }

        public decimal GetTotalDebitBalance()
        {
            var totalDebitBalance = 0m;
            var totalTransactions = Account.GetTransactionCount();
            for (var i = 0; i < totalTransactions; i++)
            {
                totalDebitBalance += Account.GetTransactionAmountIfDebitAt(i);
            }
            return totalDebitBalance;
        }
    }
}
