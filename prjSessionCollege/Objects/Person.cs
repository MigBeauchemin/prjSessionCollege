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
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    }

}
