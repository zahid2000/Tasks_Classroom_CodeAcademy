using Day15_Lesson_Part1_2.Data;
using Day15_Lesson_Part1_2.Models;

MyContext context=new MyContext();
context.Countries.Add(new Country{
Code="Cd",
Phone="Phone",
ISO="ISO",
Capital="Capi",
Currency="Curre",
Continent="Continent",
Property="Property"

});
context.SaveChanges();