using System;

namespace KleintechTestTask.Core.Models
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public Person Spouse { get; set; }
        public bool Married { get; set; }

    }
}