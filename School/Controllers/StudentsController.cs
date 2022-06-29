using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository;
using System.Collections.Generic;

namespace School.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        IRepository<Student> _repository;

        public StudentsController(IRepository<Student> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(_repository.GetAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            return Ok(_repository.GetAsync(t => t.Id == id));
        }

        [HttpGet("lookup")]
        public ActionResult<IEnumerable<Student>> Get([FromQuery] string search)
        {
            return Ok(_repository.GetWhereAsync(t => t.FirstName.StartsWith(search) || t.LastName.StartsWith(search)));
        }

        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            return CreatedAtAction("post", _repository.InsertAsync(student));

        }

        [HttpPut]
        public ActionResult<Student> Put([FromBody] Student student)
        {
            return Ok(_repository.UpdateAsync(student));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_repository.DeleteAsync(id));
        }

    }
}
