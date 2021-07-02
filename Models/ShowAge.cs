using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KleintechTestTask.Core.Models;

namespace KleintechTestTask.Models
{
    public class ShowAge
    {
        public static void ReturnAge(Person person)
        {
            var now = DateTime.Now;
            var birthDate = person.BirthDate;
            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            person.Age = age;
        }
    }
}