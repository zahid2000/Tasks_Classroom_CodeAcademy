using Microsoft.AspNetCore.Mvc;
using StateManagement_Cookie.Models;
using System.Diagnostics;

namespace StateManagement_Cookie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string COOKIE_SURVEY_KEY = "survey";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cookie = Request.Cookies[COOKIE_SURVEY_KEY];

            return View(viewName:nameof(Index),model:cookie);
        }

        [HttpPost]
        public IActionResult Index(string survey)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddSeconds(30);
            Response.Cookies.Append(COOKIE_SURVEY_KEY,survey,options);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {

            Response.Cookies.Append(COOKIE_SURVEY_KEY, "", new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(-1)
            });
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(string id)
        {
            
            Response.Cookies.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}