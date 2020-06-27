using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly DutchContext _context;

        public AppController(IMailService mailService, DutchContext context)
        {
            _mailService = mailService;
            _context = context;
        }

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
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("@DyneXvX@outlook.com", model.Subject, $"From: {model.Name} {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }

            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _context.Products
                .OrderBy(p => p.Category)
                .ToList();
            //two ways of doing the exact same thing. top is called fluent syntax 
            //bottom is the real sql query.
            var results2 = from p in _context.Products
                orderby p.Category
                select p;

            return View(results2.ToList());
        }
    }
}