using Microsoft.EntityFrameworkCore;
using Sportsplex.Models;

namespace Sportsplex.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            //LOGIN
            app.MapGet("/checkuser/{uid}", (SportsplexDbContext db, string uid) =>
            {
                var authUser = db.Users.Where(u => u.Uid == uid).FirstOrDefault();
                if (authUser == null)
                {
                    return Results.StatusCode(204);
                }
                return Results.Ok(authUser);
            });

            //Register User
            app.MapPost("/users", (SportsplexDbContext db, User userInfo) =>
            {
                db.Users.Add(userInfo);
                db.SaveChanges();
                return Results.Created($"/users/{userInfo.Id}", userInfo);
            });

            //Check User
            app.MapGet("/users/{id}", async (SportsplexDbContext db, int id) =>
            {
                User? user = await db.Users.SingleOrDefaultAsync(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });

            //Get User Details
            app.MapGet("/users/details/{uid}", async (SportsplexDbContext db, string uid) =>
            {

                User user = await db.Users.SingleOrDefaultAsync(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(user);
            });

            //Update User
            app.MapPatch("/users/{id}", (SportsplexDbContext db, int id, User user) =>
            {
                User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return Results.NotFound();
                }
                userToUpdate.Uid = user.Uid;
                userToUpdate.UserName = user.UserName;
                userToUpdate.Image = user.Image;
                userToUpdate.Email = user.Email;
                db.SaveChanges();
                return Results.Ok(userToUpdate);
            });

            // Delete User
            app.MapDelete("/users/{id}", (SportsplexDbContext db, int id) =>
            {
                var userToDelete = db.Users.FirstOrDefault(s => s.Id == id);

                if (userToDelete == null)
                {
                    return Results.NotFound("No user with matching id");
                }

                db.Users.Remove(userToDelete);
                db.SaveChanges();
                return Results.Ok("User deleted");
            });
        }
    }
}