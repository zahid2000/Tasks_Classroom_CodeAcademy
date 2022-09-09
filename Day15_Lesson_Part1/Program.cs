using System.Collections.Generic;
// dotnet tool install --global  dotnet-ef ->Toollari yukleyir
// dotnet tool update--global  dotnet-ef ->Toollari yenileyir
// dotnet ef dbcontext scaffold "server=CANR2-10\SQLEXPRESS;database=northwind;trusted_connection=true;" Microsoft.EntityFrameworkCore.SqlServer -o Models  -t Categories -t Products
// dotnet ef dbcontext scaffold "server=CANR2-10\SQLEXPRESS;database=northwind;trusted_connection=true;" Microsoft.EntityFrameworkCore.SqlServer -o Models

// 1) dotnet add package Microsoft.EntityFrameworkCore.Design
// 1) dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// --no-pluralize -> Sorguda tabloların isimlerini tekilleştirmez
// -t             -> Eklemek istediğiniz tablonun adını yazınız

// dotnet ef dbcontext scaffold "server=localhost,1433;uid=sa;database=northwind;pwd=Pro247!!;" Microsoft.EntityFrameworkCore.SqlServer -o Models  -t Categories -t Products

// dotnet ef dbcontext scaffold --help
using Day15_Lesson_Part1.Models;
northwindContext db =new northwindContext();
var customers=db.Customers.ToList();
// foreach (var customer in customers)
// {
    
//         System.Console.WriteLine( customer);
    
// }

db.Categories.Add(new Category{
CategoryName="Kategori adi",
Description="Aciklama"

});
bool result =db.SaveChanges()>0;
// System.Console.WriteLine(   $"Kategory Ekleme Islemi basari{(result ? "li":"siz")}");

db.Categories.Add(
new Category{
CategoryName="Test",
Description="Deneme",
Products=new List<Product>{
    new Product{ProductName="Urun adi",UnitPrice=5,UnitsInStock=10},
    new Product{ProductName="Urun adi",UnitPrice=5,UnitsInStock=10},
    new Product{ProductName="Urun adi",UnitPrice=5,UnitsInStock=10},
    new Product{ProductName="Urun adi",UnitPrice=5,UnitsInStock=10},
    new Product{ProductName="Urun adi",UnitPrice=5,UnitsInStock=10},
}
}

);
bool result1 =db.SaveChanges()>0;
 System.Console.WriteLine(   $"Kategory Ekleme Islemi basari{(result1 ? "li":"siz")}");

var products= db.Products.Where(x=>x.SupplierId==null).ToList();
products.ForEach(x=>x.SupplierId=15);
db.SaveChanges();