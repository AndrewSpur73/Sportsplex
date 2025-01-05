using Microsoft.EntityFrameworkCore;
using Sportsplex.Models;

namespace Sportsplex.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            // LOGIN: Check if a user exists based on their UID
            app.MapGet("/checkuser/{uid}", (SportsplexDbContext db, string uid) =>
            {
                var authUser = db.Users.Where(u => u.Uid == uid).FirstOrDefault();
                if (authUser == null)
                {
                    // Return status code 204 if no user is found with the provided UID
                    return Results.StatusCode(204);
                }
                // Return the user details if found
                return Results.Ok(authUser);
            });

            // REGISTER USER: Add a new user to the database
            app.MapPost("/users", (SportsplexDbContext db, User userInfo) =>
            {
                // Add the new user to the database
                db.Users.Add(userInfo);
                db.SaveChanges();
                // Return the created user along with its new ID
                return Results.Created($"/users/{userInfo.Id}", userInfo);
            });

            // CHECK USER: Retrieve a user based on their ID
            app.MapGet("/users/{id}", async (SportsplexDbContext db, int id) =>
            {
                User? user = await db.Users.SingleOrDefaultAsync(u => u.Id == id);
                if (user == null)
                {
                    // Return 404 if the user is not found
                    return Results.NotFound();
                }
                // Return the user details if found
                return Results.Ok(user);
            });

            // GET USER DETAILS: Retrieve a user's details based on their UID
            app.MapGet("/users/details/{uid}", async (SportsplexDbContext db, string uid) =>
            {
                User user = await db.Users.SingleOrDefaultAsync(u => u.Uid == uid);
                if (user == null)
                {
                    // Return 404 if the user is not found
                    return Results.NotFound();
                }
                // Return the user details if found
                return Results.Ok(user);
            });

            // UPDATE USER: Update a user's information based on their ID
            app.MapPatch("/users/{id}", (SportsplexDbContext db, int id, User user) =>
            {
                User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    // Return 404 if the user to update is not found
                    return Results.NotFound();
                }
                // Update the user's details
                userToUpdate.Uid = user.Uid;
                userToUpdate.UserName = user.UserName;
                userToUpdate.Image = user.Image;
                userToUpdate.Email = user.Email;
                db.SaveChanges();
                // Return the updated user details
                return Results.Ok(userToUpdate);
            });

            // DELETE USER: Remove a user from the database based on their ID
            app.MapDelete("/users/{id}", (SportsplexDbContext db, int id) =>
            {
                var userToDelete = db.Users.FirstOrDefault(s => s.Id == id);
                if (userToDelete == null)
                {
                    // Return 404 if the user to delete is not found
                    return Results.NotFound("No user with matching id");
                }
                // Remove the user from the database
                db.Users.Remove(userToDelete);
                db.SaveChanges();
                // Return a confirmation message
                return Results.Ok("User deleted");
            });

            // USERS: Retrieve a list of all users
            app.MapGet("/users", (SportsplexDbContext db) =>
            {
                // Return a list of all users
                return db.Users.ToList();
            });
        }

    }
}