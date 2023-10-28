using Microsoft.AspNetCore.Mvc;
using prjSessionCollege.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using prjSessionCollege.Objects;

namespace prjSessionCollege.Controllers
{
    public class HomeController : Controller
    {
        private string errorMsg;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            return View(viewModel);
        }

        public IActionResult Logout()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.account = "";
            return View(viewModel);
        }

        public IActionResult AccountValidate(string Username, string Password)
                            
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();

            viewModel.AccountValidate(Username, Password).Wait();

            if (viewModel.account == "")
            {
                return PartialView("_Connexion", viewModel);

            }
            else 
            {
                return PartialView("_Cours", viewModel);
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CourseSemesterGetAll()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.CourseSemesterGetAll().Wait();

            return PartialView("_Cours", viewModel);
        }

        //public IActionResult PersonGetAll()
        //{
        //    HomeViewModel viewModel = HomeViewModel.getInstance();
        //    viewModel.PersonGetAll().Wait();

        //    return PartialView("_Etudiants",viewModel); 
        //}

        //public IActionResult AddStudent(IFormCollection form)
        //{
        //    HomeViewModel viewModel = HomeViewModel.getInstance();
        //    viewModel.UpdatePerson(form["FirstName"], form["LastName"], form["Phone"], form["Email"], "Student").Wait();
        //    viewModel.PersonGetAll().Wait();

        //    return PartialView("_Etudiants", viewModel);
        //}

        public IActionResult ShowCours()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.CourseSemesterGetAll().Wait();

            return PartialView("_Cours", viewModel);
        }

        public IActionResult ShowEtudiants()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.PersonGetAll("Student").Wait();

            return PartialView("_Etudiants", viewModel);
        }

        public IActionResult ShowTeacher()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.PersonGetAll("Teacher").Wait();

            return PartialView("_Cours", viewModel);
        }

        public IActionResult ShowStudentInCourse(int CourseId)
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.CourseSemesterStudentGetAll(CourseId).Wait();

            return PartialView("_Resultat", viewModel);

        }

        public IActionResult ChangeTeacher(int courseSemesterId , int teacherId)
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.CourseSemesterUpdateTeacher(courseSemesterId, teacherId).Wait();

            //retour de message success ou erreur
            return PartialView("_Cours", viewModel);
        }
            

    }
}