using Day23_Lesson_Part2.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ProductService,ProductService>();
builder.Services.AddSingleton<ContactService,ContactService>();

var app = builder.Build();

app.MapControllerRoute(
    name: "products",
    pattern: "{controller=Product}/{action=index}/{count?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");


app.Run();
