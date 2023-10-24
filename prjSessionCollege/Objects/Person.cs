using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using prjSessionCollege.Controllers;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using prjSessionCollege.Models;

namespace prjSessionCollege.Objects
{
    public class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime created { get; set; }
        public string role { get; set; } // "Student" ou "Teacher"

    }
}
