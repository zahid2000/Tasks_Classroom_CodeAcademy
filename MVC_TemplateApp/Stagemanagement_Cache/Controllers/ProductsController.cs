using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Stagemanagement_Cache.Controllers
{
    public class ProductsController : Controller
    {
        private const string CACHE_DATE_KEY = "date";
        private const string CACHE_Product_KEY = "date";
        private IMemoryCache _memoryCache;

        public ProductsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return Ok();
        }
        public IActionResult GetDate()
        {
            if (!_memoryCache.TryGetValue(CACHE_DATE_KEY, out DateTime date))
            {
                date = DateTime.Now;
                _memoryCache.Set(CACHE_DATE_KEY, date);
            }
                return Ok(new
                {
                    _date = date.ToLongTimeString(),
                    _CurrentDate = DateTime.Now.ToLongTimeString()
                }); ;
             
           
        }
       
    }
}
