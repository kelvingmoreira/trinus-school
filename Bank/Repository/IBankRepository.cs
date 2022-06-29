using Bank.Models;

namespace Bank.Repository
{
    public interface IBankRepository
    {
        double GetNetWorth();

        double GetNetWorthByClient(int id);

        IEnumerable<Client> GetPotencialClients(double balance);

        IEnumerable<Client>? GetInactiveAccounts();

        Client InsertClient(Client client);

        Client? GetClient(int id);

        IEnumerable<Client> GetAllClients();

        Client? UpdateClient(Client client);

        bool DeleteClient(int id);

        IEnumerable<Transaction> GetAllTransactions();

        bool DeleteTransaction(int id);

        Transaction InsertTransaction(int clientId, Transaction transaction);
    }
}
