using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SharedProject;
using Store_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            DatabaseContext context = new DatabaseContext();
            List<Person> people = context.People.ToList();
            return people;
        }







        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
