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
                var transaction = Account.GetTransactionAt(i);
                if (transaction is CreditTransaction)
                {
                    totalCreditBalance += transaction.Amount;
                }
            }
            return totalCreditBalance;
        }

        public decimal GetTotalDebitBalance()
        {
            var totalDebitBalance = 0m;
            var totalTransactions = Account.GetTransactionCount();
            for (var i = 0; i < totalTransactions; i++)
            {
                var transaction = Account.GetTransactionAt(i);
                if (transaction is DebitTransaction)
                {
                    totalDebitBalance += transaction.Amount;
                }
            }
            return totalDebitBalance;
        }
    }
}
