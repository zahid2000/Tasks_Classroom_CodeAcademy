using Microsoft.AspNetCore.Mvc;
using OscarWilde.Model;
using OscarWilde.Models;

namespace OscarWilde.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly MyDbContext _myDbContext;

        public CategoryViewComponent(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var result=_myDbContext.Categories.AsEnumerable<Category>();
            return View(result);
        }
    }
}
