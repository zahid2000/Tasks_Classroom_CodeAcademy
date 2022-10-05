
using Code.Application;
using Code.Infrastructure;
using Code.Infrastructure.Persistance;
using Code.WebApi.Filters;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<ApiExceptionFilterAttribute>());
builder.Services.AddFluentValidationAutoValidation(x=>x.DisableDataAnnotationsValidation=false).AddFluentValidationClientsideAdapters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//My ConfigurationServices
builder.Services.AddApplicationServices();

builder.Services.AddInfastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope=app.Services.CreateScope())
    {
        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initializer.InitializeAsync();
        await initializer.SeedAsync();
    }
}
//app.UseAuthentication();
//app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
