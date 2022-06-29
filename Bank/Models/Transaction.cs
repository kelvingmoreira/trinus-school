namespace Bank.Models
{
    public class Transaction : DbObject
    {
        public DateTime Date { get; set; }

        public TransactionType TransactionType { get; set; }

        public double Value { get; set; }
    }

    public enum TransactionType
    {
        Deposit = 0,
        Withdrawal
    }
}
