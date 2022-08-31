using Day3_Tasks.Models;
using Day3_Tasks.Polymorphism;

//FirstClass firstClass=new FirstClass();
//firstClass.Ad = "Zahid";

Cat cat = new()
{
    Color = "Black",
    Type="Tekir"
    
 
};
Dog dog = new Dog
{
    Color="White",
    Type="Golden"
};
Bird bird = new();
bird.Color = "Blue";
bird.Type = "Sahin";

Console.WriteLine($"{typeof(Cat).Name} -> {cat.Voice()}");
Console.WriteLine($"{typeof(Dog).Name} -> {dog.Voice()}");
Console.WriteLine($"{typeof(Bird).Name} -> {bird.Voice()}");



















//   Name                instance                   inheritance
//  abstract                -                             +
//  sealed                  +                             -
//  partial                 