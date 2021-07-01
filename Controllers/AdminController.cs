using System.Web.Http;
using KleintechTestTask.Core.Models;
using KleintechTestTask.Core.Services;

namespace KleintechTestTask.Controllers
{
    public class AdminController : ApiController
    {
        private readonly IPersonService _personService;

        public AdminController()
        {

        }

        public AdminController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("UsersList")]
        public IHttpActionResult GetUsersById(int id)
        {
            var person = _personService.GetFullPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet]
        [Route("UsersList")]
        public IHttpActionResult GetUsers()
        {
            var persons = _personService.Get();
            return Ok(persons);
        }

        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult PostUsers(Person newPerson)
        {
            _personService.Create(newPerson);
            return Created("", newPerson);
        }

        [HttpPut]
        [Route("AddUser/{id1},{id2}")]
        public IHttpActionResult PutSpouse(int id1, int id2)
        {
            var spouse1 = _personService.GetById(id1);
            var spouse2 = _personService.GetById(id2);

            if (spouse1.Married || spouse2.Married)
            {
                return BadRequest("One of these persons are married");
            }

            spouse1.Spouse = spouse2;
            spouse2.Spouse = spouse1;
            spouse1.Married = true;
            spouse2.Married = true;
            return Ok();
        }

            [HttpDelete]
            [Route("DeleteUser/{id}")]
            public IHttpActionResult DeletePerson(int id)
            {

                var person = _personService.GetById(id);

                if (person == null)
                {
                    return BadRequest();
                }

                var spouse = person.Spouse;

                if (spouse == null)
                {
                    _personService.Delete(person);
                    return Ok();
                } 

                spouse.Spouse = null; 
                person.Spouse = null;
                _personService.Delete(person);
                return Ok();
            }
    }
}