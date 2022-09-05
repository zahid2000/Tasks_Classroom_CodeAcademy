using Day7_Lesson_Part1.Attributes;
using Day7_Lesson_Part1.Models;
using System.Reflection;

IEnumerable<string> GetColumnNames<T>(T entity)
{
    List<string> columnNames = new List<string>();
    foreach (PropertyInfo info in entity.GetType().GetProperties())
    {
        bool result =Attribute.IsDefined(info, typeof(ColumnName));
        if (result)
        {
            ColumnName? attr =(ColumnName?)info.GetCustomAttribute(typeof(ColumnName), false);
           
               
           columnNames.Add(attr.DisplayName ?? info.Name);
             
           
        }
    }
    return columnNames;
}

var names= GetColumnNames(new Employee());
foreach (string name in names)
{
    Console.WriteLine(name);
}