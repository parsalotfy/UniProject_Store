using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SharedProject;
using Store_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly StoreContext _context;

        public PeopleController(StoreContext context)
        {
            _context = context;
        }
      
        
        // GET: api/people
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPeople()
        {
            List<Person> people = _context.People.ToList();
            return Ok(people);
        }

        
        // GET: api/people/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Person>> GetPerson(int id)
        {
            Person person = _context.People.First(p => p.Id == id);
            return Ok(person);
        }


        //POST api/people
        [HttpPost]
        public ActionResult PostPerson([FromBody] Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return Created("Database", person);
        }


        // PUT api/people
        [HttpPut]
        public ActionResult UpdatePerson([FromBody] Person person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
            return Accepted("Database");
        }

        
        // DELETE api/people/5
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            Person person = _context.People.First(p => p.Id == id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return NoContent();
        }


        // DELETE api/people
        [HttpDelete]
        public ActionResult DeletePeople()
        {
            _context.People.RemoveRange(_context.People);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
