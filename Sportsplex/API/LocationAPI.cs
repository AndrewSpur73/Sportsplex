using Sportsplex.Models;

namespace Sportsplex.API
{
    public class LocationAPI
    {
        public static void Map(WebApplication app)
        {
            //Get Locations
            app.MapGet("/locations", (SportsplexDbContext db) =>
            {
                var locations = db.Locations.ToList();
                if (locations == null)
                {
                    return Results.StatusCode(204);
                }
                return Results.Ok(locations);
            });

            //Create Location
            app.MapPost("/locations", (SportsplexDbContext db, Location location) =>
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return Results.Created($"/locations/{location.Id}", location);
            });

            //Update Location
            app.MapPatch("/locations/{id}", (SportsplexDbContext db, int id, Location location) =>
            {
                Location locationToUpdate = db.Locations.SingleOrDefault(u => u.Id == id);
                if (locationToUpdate == null)
                {
                    return Results.NotFound();
                }
                locationToUpdate.Name = location.Name;
                db.SaveChanges();
                return Results.Ok(locationToUpdate);
            });

            // Delete Location
            app.MapDelete("/locations/{id}", (SportsplexDbContext db, int id) =>
            {
                var locationToDelete = db.Locations.FirstOrDefault(s => s.Id == id);

                if (locationToDelete == null)
                {
                    return Results.NotFound("No location with matching id");
                }

                db.Locations.Remove(locationToDelete);
                db.SaveChanges();
                return Results.Ok("Location deleted");
            });
        }
    }
}