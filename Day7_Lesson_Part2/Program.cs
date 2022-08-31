
using Day7_Lesson_Part2.Attributes;
using Day7_Lesson_Part2.Models;
using System.Reflection;
using System.Text.RegularExpressions;

void CheckEmailValid<T, TAttribute>(T entity,TAttribute attribute)
    where TAttribute:Type
{
  
    foreach (PropertyInfo info in entity.GetType().GetProperties())
    {
        bool result = Attribute.IsDefined(info,attribute);
        if (result)
        {             
            Console.WriteLine($"{info.Name} -> {info.GetValue(entity)} -> {checkEmail((string?)info.GetValue(entity))}");
        }
    }
}
void CheckPasswordValid<T, TAttribute>(T entity, TAttribute attribute)
    where TAttribute : Attribute
{
    List<string> columnNames = new List<string>();
    foreach (PropertyInfo info in entity.GetType().GetProperties())
    {
        bool result = Attribute.IsDefined(info, typeof(TAttribute));
        if (result)
        {
            Console.WriteLine($"{info.Name} -> {info.GetValue(entity)} -> {checkPassword((string?)info.GetValue(entity))}");
        }
    }
}

bool checkEmail(string? email)
{
    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");   
    Match match = regex.Match(email);
   return match.Success;
}
bool checkPassword(string password)
{
    if (password.Length<8)
    {
        return false;
    }
    else if (!Char.IsUpper(password[0]))
    {
        return false;
    }else
    {
        Regex regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-zA-Z]).*$");
        Match match = regex.Match(password);
        return match.Success;        
    }
}

CheckEmailValid(new User {Name="asgar", Email="zahid@mail.ru"}, typeof(ValidEmail));
CheckPasswordValid(new User {Name="asgar", Email="zahid@code.edu.az",Password="A1fwfdesfe2ad"}, new ValidPasssword());   
