namespace Refactoring
{
    public class MixedAccount : Account
    {
        public MixedAccount(string accountHolderName, int accountNumber) : base(accountHolderName, accountNumber)
        {
            DebitAccount = new DebitAccount(accountHolderName, accountNumber);
            CreditAccount = new CreditAccount(accountHolderName, accountNumber);
        }

        private DebitAccount DebitAccount { get; set; }
        private CreditAccount CreditAccount { get; set; }

        public void Debit(decimal amount, string recipient)
        {
            AddBalance(-amount);
            var debitTransaction = DebitAccount.Debit(amount, recipient);
            PerformTransaction(debitTransaction);            
        }

        public void Credit(decimal amount, string recipient)
        {
            AddBalance(amount);
            var debitTransaction = CreditAccount.Credit(amount, recipient);
            PerformTransaction(debitTransaction);
        }
    }
}
