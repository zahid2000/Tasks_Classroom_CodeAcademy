﻿using Microsoft.AspNetCore.Mvc;

namespace OscarWilde.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
