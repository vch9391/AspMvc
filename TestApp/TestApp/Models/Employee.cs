using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public SelectList CityList { get; set; }

        public string State { get; set; }
        public SelectList StateList { get; set; }

        public string Gender { get; set; }
    }


    public enum Gender
    {
        Male,
        Female
    }
}
