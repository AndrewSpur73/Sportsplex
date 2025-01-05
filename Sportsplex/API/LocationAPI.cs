using Sportsplex.Models;

namespace Sportsplex.API
{
    public class LocationAPI
    {
        public static void Map(WebApplication app)
        {
            // Map a GET endpoint to retrieve all locations from the database
            app.MapGet("/locations", (SportsplexDbContext db) =>
            {
                // Fetch all locations from the database and store them in a list
                var locations = db.Locations.ToList();

                // If no locations are found, return a 204 No Content status
                if (locations == null)
                {
                    return Results.StatusCode(204);
                }

                // Return the list of locations with a 200 OK status
                return Results.Ok(locations);
            });

            // Map a POST endpoint to create a new location
            app.MapPost("/locations", (SportsplexDbContext db, Location location) =>
            {
                // Add the new location to the database
                db.Locations.Add(location);

                // Save the changes to the database
                db.SaveChanges();

                // Return a 201 Created status with the new location's URL
                return Results.Created($"/locations/{location.Id}", location);
            });

            // Map a PATCH endpoint to update an existing location by its ID
            app.MapPatch("/locations/{id}", (SportsplexDbContext db, int id, Location location) =>
            {
                // Find the location with the specified ID
                Location locationToUpdate = db.Locations.SingleOrDefault(u => u.Id == id);

                // If the location is not found, return a 404 Not Found status
                if (locationToUpdate == null)
                {
                    return Results.NotFound();
                }

                // Update the name of the location
                locationToUpdate.Name = location.Name;

                // Save the changes to the database
                db.SaveChanges();

                // Return the updated location with a 200 OK status
                return Results.Ok(locationToUpdate);
            });

            // Map a DELETE endpoint to remove a location by its ID
            app.MapDelete("/locations/{id}", (SportsplexDbContext db, int id) =>
            {
                // Find the location with the specified ID
                var locationToDelete = db.Locations.FirstOrDefault(s => s.Id == id);

                // If the location is not found, return a 404 Not Found status with a message
                if (locationToDelete == null)
                {
                    return Results.NotFound("No location with matching id");
                }

                // Remove the location from the database
                db.Locations.Remove(locationToDelete);

                // Save the changes to the database
                db.SaveChanges();

                // Return a 200 OK status with a confirmation message
                return Results.Ok("Location deleted");
            });
        }
    }
}