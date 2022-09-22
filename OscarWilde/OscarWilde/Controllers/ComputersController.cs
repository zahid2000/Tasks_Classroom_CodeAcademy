using Microsoft.AspNetCore.Mvc;
using OscarWilde.Model;

namespace OscarWilde.Controllers
{
    public class ComputersController : Controller
    {
        private readonly MyDbContext _dbContext;

        public ComputersController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
