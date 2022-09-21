using Microsoft.AspNetCore.Mvc;

namespace OscarWilde.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
