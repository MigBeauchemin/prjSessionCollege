﻿using Microsoft.AspNetCore.Mvc;
using prjSessionCollege.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace prjSessionCollege.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Connexion");
        }

        public IActionResult AccountValidate(IFormCollection form)
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();

            viewModel.AccountValidate(form["Username"], form["Password"]).Wait();

            if (viewModel.account == "")
            {
                return PartialView("_Connexion",viewModel);
            }
            else 
            {
                return PartialView("_Cours", viewModel);
            }

        }

        
        public IActionResult Index()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();

            
            return View(viewModel);
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

            return RedirectToAction("Index", "Home");
        }

        public IActionResult PersonGetAll()
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.PersonGetAll().Wait();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddStudent(IFormCollection form)
        {
            HomeViewModel viewModel = HomeViewModel.getInstance();
            viewModel.UpdatePerson(form["FirstName"], form["LastName"], form["Phone"], form["Email"], "Student").Wait();
            viewModel.PersonGetAll().Wait();

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Profs_preview()
        {
            return View("Profs_preview");
        }
    }
}