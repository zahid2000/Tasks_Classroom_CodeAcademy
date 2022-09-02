using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day9_Lesson_Part1.Models;

namespace Day9_Lesson_Part1.Services
{
    public interface IRepository<T> where T : class
    {
        ICollection<Product> GetProducts(Func<Product, bool> predicate);
    }

    public class RepositoryBase<T>:IRepository<T> where T:class
    {
        List<Product> Products=new List<Product>();
        public ICollection<Product> GetProducts(Func<Product, bool> predicate)
        {
            return Products.Where(predicate).ToList();
        }
    }

    public interface IProductService
    {
        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        ICollection<Product> GetProducts();
        ICollection<Product> GetProducts(Func<Product,bool> predicate);
    }

    public class ProductService:IProductService
    {
        public ICollection<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProducts(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
