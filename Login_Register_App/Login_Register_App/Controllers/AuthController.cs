using Login_Register_App.Models;
using Login_Register_App.Services;
using Login_Register_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Login_Register_App.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        private const string LOGIN_DATA_KEY = "login";
        private const string REGISTER_DATA_KEY = "register";
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Login()
        {
          
            return View(true);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var result=authService.Login(model);
            if (!result)
            {
                return View(result);
                
            }
            Response.Cookies.Append(LOGIN_DATA_KEY, model.UserName, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(5)
            });
            return RedirectToAction(nameof(Index), controllerName: "Home");

        }
        public IActionResult Register( )
        {          
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var result = authService.Register(model);
            if (!result)
            {
                return View(model);

            }
            Response.Cookies.Append(REGISTER_DATA_KEY, model.User.UserName, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(5)
            });
            return RedirectToAction("Index", "Home");

        }
        public IActionResult LogOut()
        {
            var loginResult = Request.Cookies[LOGIN_DATA_KEY];
            var registerResult = Request.Cookies[REGISTER_DATA_KEY];
            if (!string.IsNullOrEmpty(loginResult))
            {
                Response.Cookies.Delete(REGISTER_DATA_KEY);
                Response.Cookies.Delete(LOGIN_DATA_KEY);
                return RedirectToAction("Index", "Home");

            }
                return NotFound();
      

        }
    }
}
