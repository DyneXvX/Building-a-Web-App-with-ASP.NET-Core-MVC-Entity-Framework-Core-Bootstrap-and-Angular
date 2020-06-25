using System;
using System.Security.AccessControl;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidOperationException("Test");
            return View();
        }

        [HttpGet("contact")] //this removes the localhost:8888/App/Contact and makes it just localhost:8888/contact
        public IActionResult Contact()
        {
            

            return View();
            
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
    }
}