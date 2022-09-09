using CodeFirstNorthwind.Models;
northwindContext context=new northwindContext();
context.Categories.Add(new Category{
    CategoryName="Kategori adi",
    Description="Aciklama"
});
bool result =context.SaveChanges()>0;
System.Console.WriteLine(result);
using (context=new northwindContext())
{
    context.Categories.Update(new Category{
    CategoryId=16,
    CategoryName="Kategori adi",
    Description="Aciklamaaaaaa"
});
bool UpdateResult=context.SaveChanges()>0;
System.Console.WriteLine($"Update basari{(UpdateResult?"li":"siz")}");
} 


using (context=new northwindContext())
{
  context.Categories.Remove(new Category{
    CategoryId=16,
    CategoryName="Kategori adi",
    Description="Aciklama"
});
bool RemoveResult=context.SaveChanges()>0;
System.Console.WriteLine($"Silme basari{(RemoveResult?"li":"siz")}");
}
