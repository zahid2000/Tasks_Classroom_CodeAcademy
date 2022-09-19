using Day23_Lesson_Part2.Models;
using Day23_Lesson_Part2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day23_Lesson_Part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        private readonly ContactService _contactService;


        public HomeController(ProductService productService, ContactService contactService)
        {
            _productService = productService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            List<Product> products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Contact()
        {
            List<Contact> contacts=_contactService.GetAll();
            return View(contacts);
        }
    }
}
