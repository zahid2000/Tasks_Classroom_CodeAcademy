using Day24_Lesson_Part1.Models;
using Day24_Lesson_Part1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Day24_Lesson_Part1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly northwindContext _context;

        public CategoriesController(northwindContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Select(x=>new CategoryVM
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description=x.Description
            });
            //ViewData["CategoriesViewData"] = categories.Skip(5).Take(5);
            //TempData["CategoriesTempData"]=categories.Where(x=>x.CategoryId%2==0).Take(5).ToList();

            //ViewData["CodeEdu"] = "Code Academy - view data";
            //TempData["CodeEduAz"] = "Code Academy - Temp data";
            //ViewBag.CategoriesViewBag= categories.Where(x => x.CategoryId % 2 == 0).Take(5).ToList();


            var c1 = categories.Where(x => x.CategoryId % 2 == 0).Take(5).AsEnumerable();
            var c2 = categories.Where(x => x.CategoryId % 3 == 0).Take(5).AsEnumerable();
            var c3 = categories.Where(x => x.CategoryId % 2 != 0).Take(5).AsEnumerable();
            var c4 = categories.Where(x => x.CategoryId % 3 != 0).Take(5).AsEnumerable();
            var tuple= Tuple.Create(c1, c2, c3, c4,"Code Academy",DateTime.Now);
            return View(tuple);
        }
        public IActionResult Create()
        {
            ViewData["CodeEdu1"] = "Code Academy1 - view data";
            TempData["CodeEduAz1"] = "Code Academy1 - Temp data";
            return View();
        }
    }
}
