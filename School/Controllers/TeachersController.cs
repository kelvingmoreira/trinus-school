using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : Controller
    {
        IRepository<Teacher> _repository;
        public TeachersController(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> Get()
        {
            return Ok(_repository.GetAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            return Ok(_repository.GetAsync(t => t.Id == id));
        }

        [HttpGet("lookup")]
        public ActionResult<IEnumerable<Teacher>> Get([FromQuery] string search)
        {
            return Ok(_repository.GetWhereAsync(t => t.FirstName.StartsWith(search) || t.LastName.StartsWith(search)));
        }

        [HttpPost]
        public ActionResult<Teacher> Post([FromBody] Teacher teacher)
        {
            return CreatedAtAction("post", _repository.InsertAsync(teacher));
        }

        [HttpPut]
        public ActionResult<Teacher> Put([FromBody] Teacher teacher)
        {
            return Ok(_repository.UpdateAsync(teacher));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_repository.DeleteAsync(id));
        }
    }
}
