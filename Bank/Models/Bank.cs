namespace Bank.Models
{
    public class BankBase : DbObject
    {
        public BankBase()
        {
            Clients = new();
        }

        public List<Client>? Clients { get; set; }

    }
}
