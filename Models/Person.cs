using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KleintechTestTask.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public DateTime BirthDate { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public Person Spouse { get; set; }
        public bool Married { get; set; }

    }
}