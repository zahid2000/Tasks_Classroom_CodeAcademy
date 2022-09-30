using WebAPI.Data;

namespace WebAPI.Dtos.CategoryDtos;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
    public string? FullProperty { get; set; }
}


public static class CategoryEndpoints
{
//	public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
//    {
//        routes.MapGet("/api/Category", async (NorthwindDbContext db) =>
//        {
//            return await db.Categories.ToListAsync();
//        })
//        .WithName("GetAllCategorys")
//        .Produces<List<Category>>(StatusCodes.Status200OK);

//        routes.MapGet("/api/Category/{id}", async (int CategoryId, NorthwindDbContext db) =>
//        {
//            return await db.Categories.FindAsync(CategoryId)
//                is Category model
//                    ? Results.Ok(model)
//                    : Results.NotFound();
//        })
//        .WithName("GetCategoryById")
//        .Produces<Category>(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound);

//        routes.MapPut("/api/Category/{id}", async (int CategoryId, Category category, NorthwindDbContext db) =>
//        {
//            var foundModel = await db.Categories.FindAsync(CategoryId);

//            if (foundModel is null)
//            {
//                return Results.NotFound();
//            }
//            //update model properties here

//            await db.SaveChangesAsync();

//            return Results.NoContent();
//        })   
//        .WithName("UpdateCategory")
//        .Produces(StatusCodes.Status404NotFound)
//        .Produces(StatusCodes.Status204NoContent);

//        routes.MapPost("/api/Category/", async (Category category, NorthwindDbContext db) =>
//        {
//            db.Categories.Add(category);
//            await db.SaveChangesAsync();
//            return Results.Created($"/Categorys/{category.CategoryId}", category);
//        })
//        .WithName("CreateCategory")
//        .Produces<Category>(StatusCodes.Status201Created);


//        routes.MapDelete("/api/Category/{id}", async (int CategoryId, NorthwindDbContext db) =>
//        {
//            if (await db.Categories.FindAsync(CategoryId) is Category category)
//            {
//                db.Categories.Remove(category);
//                await db.SaveChangesAsync();
//                return Results.Ok(category);
//            }

//            return Results.NotFound();
//        })
//        .WithName("DeleteCategory")
//        .Produces<Category>(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound);
//    }
//}
}