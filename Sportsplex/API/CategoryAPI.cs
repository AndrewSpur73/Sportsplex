using Sportsplex.Models;

namespace Sportsplex.API
{
    public class CategoryAPI
    {
        public static void Map(WebApplication app)
        {
            // Get all categories from the database
            app.MapGet("/categories", (SportsplexDbContext db) =>
            {
                // Retrieve the list of categories
                var categories = db.Categories.ToList();
                // Return a 204 No Content status if no categories are found
                if (categories == null)
                {
                    return Results.StatusCode(204);
                }
                // Return the list of categories with a 200 OK status
                return Results.Ok(categories);
            });

            // Create a new category
            app.MapPost("/categories", (SportsplexDbContext db, Category category) =>
            {
                // Add the new category to the database
                db.Categories.Add(category);
                // Save the changes to the database
                db.SaveChanges();
                // Return a 201 Created status with the new category's URI and data
                return Results.Created($"/categories/{category.Id}", category);
            });

            // Update an existing category by ID
            app.MapPatch("/categories/{id}", (SportsplexDbContext db, int id, Category category) =>
            {
                // Find the category to update by ID
                Category categoryToUpdate = db.Categories.SingleOrDefault(u => u.Id == id);
                // Return a 404 Not Found status if the category does not exist
                if (categoryToUpdate == null)
                {
                    return Results.NotFound();
                }
                // Update the category's name
                categoryToUpdate.Name = category.Name;
                // Save the changes to the database
                db.SaveChanges();
                // Return the updated category with a 200 OK status
                return Results.Ok(categoryToUpdate);
            });

            // Delete an existing category by ID
            app.MapDelete("/categories/{id}", (SportsplexDbContext db, int id) =>
            {
                // Find the category to delete by ID
                var categoryToDelete = db.Categories.FirstOrDefault(s => s.Id == id);

                // Return a 404 Not Found status if the category does not exist
                if (categoryToDelete == null)
                {
                    return Results.NotFound("No category with matching id");
                }

                // Remove the category from the database
                db.Categories.Remove(categoryToDelete);
                // Save the changes to the database
                db.SaveChanges();
                // Return a 200 OK status with a deletion confirmation message
                return Results.Ok("Category deleted");
            });
        }
    }
}