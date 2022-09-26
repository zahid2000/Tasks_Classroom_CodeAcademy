using Microsoft.AspNetCore.Mvc;

namespace Login_Register_App.ViewComponents
{
	public class Navbar:ViewComponent
	{
        private const string LOGIN_DATA_KEY = "login";
        private const string REGISTER_DATA_KEY = "register";

        public IViewComponentResult Invoke()
		{
			string model = "";
			var loginResult = Request.Cookies[LOGIN_DATA_KEY];
			var registerResult = Request.Cookies[REGISTER_DATA_KEY];
			if (!string.IsNullOrEmpty(loginResult))
				model = "login";
			else if (!string.IsNullOrEmpty(registerResult))
				model = "register";
            return View(model:model);
		}
	}
}
