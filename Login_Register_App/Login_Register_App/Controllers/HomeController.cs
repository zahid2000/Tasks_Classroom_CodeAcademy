using Login_Register_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Login_Register_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string LOGIN_DATA_KEY = "login";
        private readonly LoginRegisterDb _db;



        public HomeController(ILogger<HomeController> logger, LoginRegisterDb db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            var loginResult=Request.Cookies[LOGIN_DATA_KEY];
            if (string.IsNullOrEmpty(loginResult))
                return NotFound();

            var result=_db.Users.FirstOrDefault(x=>x.UserName == loginResult);
            return View(result);
           
        }
        public IActionResult Chat()
        {
            var loginResult = Request.Cookies[LOGIN_DATA_KEY];
            if (string.IsNullOrEmpty(loginResult))
                return NotFound();
            return View(model:loginResult);
        }

        
    }
}