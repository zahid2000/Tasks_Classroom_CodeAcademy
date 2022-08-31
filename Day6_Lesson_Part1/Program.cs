using Day6_Lesson_Part1.Models;

void SetEntity<T>(T entity)
{
    if (entity is Type)
    {
        T object1 = (T)Activator.CreateInstance(Type.GetType(entity.ToString()));
        foreach (var item in object1.GetType().GetProperties())
        {
            if (item.PropertyType.Name == "String")
            {
                item.SetValue(object1, item.Name);
            }
            if (item.PropertyType.Name == "Int32")
            {
                item.SetValue(object1, 5);
            }
            if (item.PropertyType.Name == "Single")
            {
                item.SetValue(object1, 2);
            }
            Console.WriteLine($"{item.Name}                {item.PropertyType.Name}               {item.GetValue(object1)}");
        }
    }
    else
    {

        foreach (var item in entity.GetType().GetProperties())
        {
            if (item.PropertyType.Name == "String")
            {
                item.SetValue(entity, item.Name);
            }
            if (item.PropertyType.Name == "Int32")
            {
                item.SetValue(entity, 5);
            }
            if (item.PropertyType.Name == "Single")
            {
                item.SetValue(entity, 2);
            }
            Console.WriteLine($"{item.Name}                {item.PropertyType.Name}               {item.GetValue(entity)}");
        }
    }
}
Product p=new Product();
//SetEntity<Product>(p);
SetEntity (typeof(Product));