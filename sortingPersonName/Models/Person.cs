using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sortingPersonName.Models
{
    public class Person
    {
        public Person(string firstName,string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}