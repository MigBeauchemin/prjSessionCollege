using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using prjSessionCollege.Controllers;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using prjSessionCollege.Objects;
using prjSessionCollege.Models;
using prjSessionCollege.JSON;
using Microsoft.AspNetCore.Http;

namespace prjSessionCollege.Models
{
    public class ProfsModel
    {
        public List<Person> Teachers { get; set; }
        public List<Person> Persons { get; set; }
        public List<CourseSemesterStudent> Grades { get; set; }
        public List<string> Course { get; set; }
        public List<string> Students { get; set; }
        public string SelectCourse { get; set; }
        public string SelectStudent { get; set; }
        public string SelectGrade { get; set; }
        public string SelectComment { get; set; }
    }
}

//MODEL PROFS N'EST PAS DEMANDÉ DANS LE TP MAIS IL EST QUAND MÊME CRÉÉ SI ON VEUT L'UTILISER PLUS TARD OU QUE L'ON VOIT QUE C'EST NÉCESSAIRE