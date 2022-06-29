using Bank.Models;
using System.Linq;

namespace Bank.Repository
{
    public class BankRepository : IBankRepository
    {
        private BankBase _bank;

        public BankRepository()
        {
            _bank = new BankBase();
        }

        public bool DeleteClient(int id)
        {
            Client? client = _bank?.Clients?.SingleOrDefault(x => x.Id == id);

            if (client != null)
            {
                return _bank!.Clients!.Remove(client);
            }
            return false;
        }

        public bool DeleteTransaction(int id)
        {
            Transaction? transactionToBeRemoved = GetAllClients().SelectMany(x => x.Transactions!).FirstOrDefault(y => y.Id == id);
            
            if(transactionToBeRemoved != null)
            {
                Client client = GetAllClients().Single(x => x.Transactions!.Contains(transactionToBeRemoved!));
                return client.Transactions!.Remove(transactionToBeRemoved);
            }
            return false;
            
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _bank.Clients!;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _bank.Clients!.SelectMany(x => x.Transactions!);
        }

        public Client? GetClient(int id)
        {
            return _bank!.Clients!.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Client>? GetInactiveAccounts()
        {
            IEnumerable<Client> clients = GetAllClients();

            if (clients.Any())
            {
                return clients.Where(x => x.Transactions!.Count > 0 && (x.Transactions!.Max(x => x.Date) - DateTime.Today).Days >= 10);
            }
            return null;

            //return from client in _bank.Clients
            //from transaction in client.Transactions!
            //where (transaction.Date - DateTime.Today).Days >= 10
            //select client;

        }

        public double GetNetWorth()
        {
            return _bank!.Clients!
                    .Sum(x => x.Transactions!
                                .Where(y => y.TransactionType == TransactionType.Deposit)
                                .Sum(y => y.Value)) -
                    _bank!.Clients!
                    .Sum(x => x.Transactions!
                                .Where(y => y.TransactionType == TransactionType.Withdrawal)
                                .Sum(y => y.Value));
        }

        public double GetNetWorthByClient(int id)
        {
            Client? client = GetClient(id);

            if(client != null)
            {
                return client.Transactions!.Where(y => y.TransactionType == TransactionType.Deposit).Sum(y => y.Value) -
                       client.Transactions!.Where(y => y.TransactionType == TransactionType.Withdrawal).Sum(y => y.Value);
            }
            throw new Exception("Cliente não encontrado");

        }

        public IEnumerable<Client> GetPotencialClients(double balance)
        {
            List<Client> clients = GetAllClients().ToList();

            return clients.Where(x => GetNetWorthByClient(x.Id) > balance);
        }

        public Client InsertClient(Client client)
        {
            IEnumerable<Client> clients = _bank!.Clients!.Where(x => x.Id == client.Id);

            if (clients.Any())
            {
                throw new Exception("o Id deve ser único");
            }
            _bank!.Clients!.Add(client);
            return client;

        }

        public Transaction InsertTransaction(int clientId, Transaction transaction)
        {
            Client? actualClient = GetClient(clientId);

            if(actualClient != null)
            {
                actualClient?.Transactions?.Add(transaction);
                return transaction;   
            }
            throw new Exception("Cliente da transação não encontrado");

        }

        public Client? UpdateClient(Client? entity)
        {
            Client? client = _bank?.Clients?.SingleOrDefault(x => x.Id == entity?.Id);

            if(client != null)
            {
                return _bank!.Clients![_bank.Clients.IndexOf(client)] = entity!;
            }
            throw new Exception("Cliente não existe");
        }
    }
}
