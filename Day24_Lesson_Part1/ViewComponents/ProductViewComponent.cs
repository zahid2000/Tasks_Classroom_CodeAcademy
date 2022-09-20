using Day24_Lesson_Part1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day24_Lesson_Part1.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly northwindContext _northwindContext;

        public ProductViewComponent(northwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        public IViewComponentResult Invoke(int id)
        {
            var result = _northwindContext.Products.Where(x => x.CategoryId == id).AsEnumerable();
            return View(model:result);
        }
    }
}
