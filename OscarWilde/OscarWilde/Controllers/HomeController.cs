using Microsoft.AspNetCore.Mvc;
using OscarWilde.Model;
using OscarWilde.Models;
using OscarWilde.ViewModels;

namespace OscarWilde.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _dbContext;

        public HomeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(string name)
        {
            PhoneAndCompViewModel model;
            if (name==null)
            {
                 model = new()
                {
                    Phones = _dbContext.Phones.AsEnumerable(),
                    Computers = _dbContext.Computers.AsEnumerable()
                };
              
            }
            else
            {
                var pResult = from c in _dbContext.Categories
                              join p in _dbContext.Phones on c.Id equals p.CategoryId
                              where c.Name==name
                              select new Phone
                              {
                                  Name = p.Name,
                                  Price = p.Price,
                                  PhoneNumber = p.PhoneNumber,
                              };
                var cResult= from c in _dbContext.Categories
                             join co in _dbContext.Computers on c.Id equals co.CategoryId
                             where c.Name == name
                             select new Computer
                             {
                                 Name = co.Name,
                                 Price = co.Price
                             };
                model = new()
                {
                    Phones = pResult.AsEnumerable<Phone>(),
                     Computers = cResult.AsEnumerable<Computer>()
                };
               
            }
            return View(model);

        }
    }
}
