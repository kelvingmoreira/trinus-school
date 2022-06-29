namespace Bank.Models
{
    public class Client : DbObject
    {
        public string? Name { get; set; }

        public string? Agency { get; set; }

        public string? Account { get; set; }

        public List<Transaction>? Transactions { get; set; }

        public Client()
        {
            Transactions = new();
        }

    }
}
