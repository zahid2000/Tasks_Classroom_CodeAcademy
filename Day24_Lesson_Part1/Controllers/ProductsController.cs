using Microsoft.AspNetCore.Mvc;

namespace Day24_Lesson_Part1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
