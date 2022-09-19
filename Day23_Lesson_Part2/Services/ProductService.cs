using Day23_Lesson_Part2.Models;
using System.Linq;

namespace Day23_Lesson_Part2.Services
{
    public class ProductService
    {
        List<Product> _db = new List<Product>
        {
            new Product{Id=1,ProductName="Alma",Price=122,RelaseDate=new DateTime(2022,04,01),Count=3},
            new Product{Id=2,ProductName="Armud",Price=12,RelaseDate=new DateTime(2022,2,01),Count=44},
            new Product{Id=3,ProductName="Nar",Price=162,RelaseDate=new DateTime(2022,5,01),Count=33},
            new Product{Id=4,ProductName="Heyva",Price=33,RelaseDate=new DateTime(2022,5,01),Count=21},
            new Product{Id=5,ProductName="Qarpiz",Price=21,RelaseDate=new DateTime(2022,4,01),Count=21},
            new Product{Id=6,ProductName="Gilas",Price=544,RelaseDate=new DateTime(2022,1,01),Count=21},
            new Product{Id=7,ProductName="Uzum",Price=12,RelaseDate=new DateTime(2022,01,2),Count=54},
            new Product{Id=8,ProductName="Bal",Price=343,RelaseDate=new DateTime(2022,01,5),Count=32},
        };

        public List<Product> GetAll()
        {
            return _db;
        }
        public List<Product> GetAllCount(int count)
        {
             
                return _db.Take(count).ToList();
             
        }
        public void Add(Product product)
        {
            _db.Add(product);
        }

        public Product GetById(int id)
        {
            return _db.FirstOrDefault(x => x.Id == id);
        }
    }
}
