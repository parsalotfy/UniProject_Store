using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SharedProject;
using Store_API.Models;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private DatabaseContext context = new DatabaseContext();

        // GET: api/people
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAllPeople()
        {
            List<Person> people = context.People.ToList();
            return Ok(people);
        }


        // GET: api/people/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Person>> GetPersonById(int id)
        {
            Person person = context.People.First(p => p.Age == id);
            return Ok(person);
        }


        //POST api/people
        [HttpPost]
        public ActionResult PostNewPerson([FromBody] Person person)
        {
            context.People.Add(person);
            context.SaveChanges();
            return Created("Database", person);
        }


        // PUT api/people
        [HttpPut]
        public ActionResult UpdatePerson([FromBody] Person person)
        {
            context.People.Update(person);
            context.SaveChanges();
            return Accepted("Database");
        }

        
        // DELETE api/people/5
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            Person person = context.People.First(p => p.Id == id);
            context.People.Remove(person);
            context.SaveChanges();
            return NoContent();
        }


        // DELETE api/people
        [HttpDelete]
        public ActionResult DeleteAll()
        {
            context.People.RemoveRange(context.People);
            context.SaveChanges();
            return NoContent();
        }



    }
}
