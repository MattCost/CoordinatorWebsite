using System;
using System.ComponentModel.DataAnnotations;

namespace CoordinatorWebpage.Models
{
    public class Coordinator
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SignupName {get;set;}
        public string FullName { get { return FirstName + " " + LastName;}}

    }
}
