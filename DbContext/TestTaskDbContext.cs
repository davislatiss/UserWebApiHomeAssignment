using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KleintechTestTask.Models;


namespace KleintechTestTask.DbContext
{
    public class TestTaskDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}