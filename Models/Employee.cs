﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Token_2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}