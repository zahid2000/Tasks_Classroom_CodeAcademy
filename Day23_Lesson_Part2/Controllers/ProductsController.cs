using Day23_Lesson_Part2.Models;
using Day23_Lesson_Part2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day23_Lesson_Part2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int count)
        {
            List<Product> products;
            if (count!=0)
            {
                products = _productService.GetAllCount(count);
                return View(products);
            }
             products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Detail(int id)
        {            
            Product product= _productService.GetById(id);
            return View(product);
        }




    }
}
