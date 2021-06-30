using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using KleintechTestTask.DbContext;
using KleintechTestTask.Models;

namespace KleintechTestTask.Controllers
{
    public class AdminController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("UsersList")]
        public IHttpActionResult GetUsers()
        {
            using (TestTaskDbContext testTaskDbContext = new TestTaskDbContext())
            {
                var users = testTaskDbContext.Persons.Where(u => u.Id > -1);
                return Ok(users.ToList());
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddUser")]
        public IHttpActionResult PostUsers(Person newPerson)
        {
            using (TestTaskDbContext testTaskDbContext = new TestTaskDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                testTaskDbContext.Persons.Add(newPerson);
                testTaskDbContext.SaveChanges();
                return Created("", newPerson);
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("AddUser/{id1},{id2}")]
        public IHttpActionResult PutSpouse(int id1, int id2)
        {
            using (TestTaskDbContext testTaskDbContext = new TestTaskDbContext())
            {
                var spouse1 = testTaskDbContext.Persons.FirstOrDefault(p => p.Id == id1);
                var spouse2 = testTaskDbContext.Persons.FirstOrDefault(p => p.Id == id2);

                if (spouse1.Married == false & spouse2.Married == false)
                {
                    spouse1.Spouse = spouse2;
                    spouse2.Spouse = spouse1;
                    spouse1.Married = true;
                    spouse2.Married = true;
                }

                testTaskDbContext.SaveChanges();
                return Ok();
            }
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("DeleteUser/{id}")]
        public IHttpActionResult DeletePerson(int id)
        {
            using (TestTaskDbContext testTaskDbContext = new TestTaskDbContext())
            {
                var person = testTaskDbContext.Persons.Include(p => p.Spouse).FirstOrDefault(p => p.Id == id);

                if (person == null)
                {
                    return BadRequest();
                }

                var spouse = person.Spouse;
                
                if (spouse == null)
                {
                    testTaskDbContext.Persons.Remove(person);
                    testTaskDbContext.SaveChanges();
                    return Ok();
                }

                spouse.Spouse = null;
                person.Spouse = null;

                testTaskDbContext.Persons.Remove(person);
                testTaskDbContext.SaveChanges();
                return Ok();
            }
        }
    }
}