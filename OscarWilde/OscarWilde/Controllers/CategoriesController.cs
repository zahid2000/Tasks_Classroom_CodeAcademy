using Microsoft.AspNetCore.Mvc;
using OscarWilde.Model;
using OscarWilde.Models;

namespace OscarWilde.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MyDbContext _myDbContext;

        public CategoriesController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public IActionResult Index()
        {
            //var result = _myDbContext.Categories.AsEnumerable<Category>();
            //if (result==null)
            //{
            //    return NotFound();
            //}
            //return View(result);
            return View();
        }
    }
}
