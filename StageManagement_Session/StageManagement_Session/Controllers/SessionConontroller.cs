using Microsoft.AspNetCore.Mvc;

namespace StageManagement_Session.Controllers
{
    public class SessionConontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
