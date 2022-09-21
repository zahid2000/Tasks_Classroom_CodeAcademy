using Microsoft.AspNetCore.Mvc;
using OscarWilde.Model;
using OscarWilde.Models;

namespace OscarWilde.Controllers
{
    public class PhonesController : Controller
    {
        private readonly MyDbContext _myDbContext;

        public PhonesController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public IActionResult Index()
        {
            var result=_myDbContext.Phones.AsEnumerable<Phone>();
            return View(result);
        }
    }
}
