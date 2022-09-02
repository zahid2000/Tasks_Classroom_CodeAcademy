using Day9_Lesson_Part2.Models;
using Day9_Lesson_Part2.Services;

Book book1 = new Book("Harry Potter", "Zahid", 344);
Book book2 = new Book("Harry Potter1", "Yusif", 200);
Book book3 = new Book("Harry Potter2", "Nadir", 300);
Book book4 = new Book("Harry Potter3", "Elcin", 453);
Book book5 = new Book("Harry Potter1", "Yusif", 111);
Book book6 = new Book("Harry Potter2", "Asgar", 500);


Library library = new Library() { };
library.Books = new List<Book>() { book1, book2, book3, book4, book5 };

LibrayService service = new LibrayService(library);

while (true)
{
    Console.WriteLine($"1.Find All Books by name\n2.Remove All books by name\n3.Search Books by name\n4.Find All Books by Page Count range\n5.Remove Book by name\n6.Get All Books\n7.Exit");

    string answer = Console.ReadLine();
    if (answer == "1")
    {
        FindAllBooks(service);
    }
    else if (answer == "2")
    {
        RemoveAllBooks(service);
    }
    else if(answer == "3")
    {
        SearchBooks(service);
    }
    else if (answer == "4")
    {
       FindAllBooksbyPageCountRange(service);
    }
    else if (answer == "5")
    {
        RemoveBook(service);
    }
    else if (answer == "6")
    {
       GetAllBooks(library);
    }
    else if (answer == "7")
    {
        break;
    }

}


void FindAllBooks(LibrayService librayService)
{
    foreach (var item in librayService.FindAllBooks(b => b.Name == "Harry Potter1"))
    {
        Console.WriteLine(
            $"Name : {item.Name} AuthorName : {item.AuthorName} PageCount : {item.PageCount} Code : {item.GetCode()}");
    }
}

void FindAllBooksbyPageCountRange(LibrayService service1)
{
    foreach (var item in service1.FindAllBooksbyPageCountRange(b => b.PageCount >= 200 && b.PageCount <= 400))
    {
        Console.WriteLine(
            $"Name : {item.Name} AuthorName : {item.AuthorName} PageCount : {item.PageCount} Code : {item.GetCode()}");
    }
}

void RemoveBook(LibrayService librayService1)
{
    librayService1.RemoveBook(b => b.GetCode() == "HA102");
}

void GetAllBooks(Library library1)
{
    foreach (var item in library1.Books)
    {
        Console.WriteLine(
            $"Name : {item.Name} AuthorName : {item.AuthorName} PageCount : {item.PageCount} Code : {item.GetCode()}");
    }
}

void SearchBooks(LibrayService service2)
{
    foreach (var item in service2.SearcBooks(b => b.AuthorName == "Zahid"))
    {
        Console.WriteLine(
            $"Name : {item.Name} AuthorName : {item.AuthorName} PageCount : {item.PageCount} Code : {item.GetCode()}");
    }
}

void RemoveAllBooks(LibrayService librayService2)
{
    librayService2.RemoveAllBooks(b => b.Name == "Harry Potter1");
}
