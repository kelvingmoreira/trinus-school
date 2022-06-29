using Bank.Models;
using Bank.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {
        IBankRepository _repository;

        public TransactionsController(IBankRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            return Ok(_repository.GetAllTransactions());
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok(_repository.DeleteTransaction(id));
        }
        
    }
}
