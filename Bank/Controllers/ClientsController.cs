using Bank.Models;
using Bank.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        IBankRepository _repository;

        public ClientsController(IBankRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return Ok(_repository.GetAllClients());
        }

        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            return Ok(_repository.GetClient(id));
        }

        [HttpGet("inactive")]
        public ActionResult<IEnumerable<Client>> GetInactiveAccounts()
        {
            return Ok(_repository.GetInactiveAccounts());
        }

        [HttpGet("networth")]
        public ActionResult<Client> GetNetWorth()
        {
            return Ok(_repository.GetNetWorth());
        }

        [HttpGet("networth/{id}")]
        public ActionResult<Client> GetNetWorthByClient(int id)
        {
            return Ok(_repository.GetNetWorthByClient(id));
        }

        [HttpGet("potencialclients")]
        public ActionResult<Client> GetPotencialClients(double balace)
        {
            return Ok(_repository.GetPotencialClients(balace));
        }


        [HttpPost]
        public ActionResult<Client> Post([FromBody] Client client)
        {
            return CreatedAtAction("post", _repository.InsertClient(client));
        }


        [HttpPost("{clientId}/transactions")]
        public ActionResult<Transaction> Post(int clientId, [FromBody] Transaction transaction)
        {
            return CreatedAtAction("post", _repository.InsertTransaction(clientId, transaction));
        }

        [HttpPut]
        public ActionResult<Client> Put([FromBody] Client client)
        {
            return Ok(_repository.UpdateClient(client));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_repository.DeleteClient(id));
        }
    }
}
