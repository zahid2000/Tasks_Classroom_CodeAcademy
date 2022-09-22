using Microsoft.AspNetCore.Mvc;
using MVC_TemplateApp.Models;
using System.Diagnostics;

namespace MVC_TemplateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var products = new List<Product>
            {
                new Product{
                    Name="Fresh organic kiwi",
                    StartPrice=10,
                    Price=70    ,
                    Rate=3,
                    ProductPhotos=new List<ProductPhoto>{
                        new ProductPhoto{
                            Url="/images/products/product-image-2-1.jpg"
                        },
                        new ProductPhoto{
                              Url="/images/products/product-image-2-2.jpg"
                        }
                    }
                },
                new Product{
                     Name="Dried mango",
                     StartPrice=10,
                     Price=70    ,
                     Rate=2,
                     ProductPhotos=new List<ProductPhoto>{
                         new ProductPhoto{
                             Url="/images/products/product-image-1-1.jpg"
                         },
                         new ProductPhoto{
                               Url="/images/products/product-image-1-2.jpg"
                         }
                     }
                 },
                new Product{
                     Name="Dried banana",
                     StartPrice=60,
                     Price=80    ,
                     Rate=4,
                     ProductPhotos=new List<ProductPhoto>{
                         new ProductPhoto{
                             Url="/images/products/product-image-3-1.jpg"
                         },
                         new ProductPhoto{
                               Url="/images/products/product-image-3-2.jpg"
                         }
                     }
                  },
                new Product{
                        Name="Crunchy crisp",
                        StartPrice=50,
                        Price=90    ,
                        Rate=5,
                        ProductPhotos=new List<ProductPhoto>{
                            new ProductPhoto{
                                Url="/images/products/product-image-4-1.jpg"
                            },
                            new ProductPhoto{
                                    Url="/images/products/product-image-4-2.jpg"
                            }
                        }
                  },
                new Product{
                          Name="Jewel cranberries",
                          StartPrice=60,
                          Price=67    ,
                          Rate=4,
                          ProductPhotos=new List<ProductPhoto>{
                              new ProductPhoto{
                                  Url="/images/products/product-image-5-1.jpg"
                              },
                              new ProductPhoto{
                                      Url="/images/products/product-image-5-2.jpg"
                              }
                          }
                    },
                new Product{
           Name="Fresh Broccoli",
           StartPrice=60,
           Price=68  ,
           Rate=5,
           ProductPhotos=new List<ProductPhoto>{
               new ProductPhoto{
                   Url="/images/products/product-image-6-1.jpg"
               },
               new ProductPhoto{
                       Url="/images/products/product-image-6-2.jpg"
               }
           }
     }
            };
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}