using Microsoft.EntityFrameworkCore;
using Sportsplex.DTO;
using Sportsplex.Models;

namespace Sportsplex.API
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            // Get all comments for a specific booking by booking ID
            app.MapGet("/comments/bookings/{id}", async (SportsplexDbContext db, int id) =>
            {
                // Retrieve the list of comments including user details where the booking ID matches
                var comments = await db.Comments.Include(c => c.User).Where(c => c.BookingId == id).ToListAsync();

                // Return a 404 Not Found status if no comments are found
                if (comments == null)
                {
                    return Results.NotFound("comment is null");
                }

                // Return the list of comments with a 200 OK status
                return Results.Ok(comments);
            });

            // Create a new comment
            app.MapPost("/comments", (SportsplexDbContext db, CreateCommentDTO newCommentDTO) =>
            {
                // Create a new Comment object from the DTO
                var newComment = new Comment
                {
                    Content = newCommentDTO.Content,
                    UserId = newCommentDTO.UserId,
                    BookingId = newCommentDTO.BookingId,
                };

                try
                {
                    // Add the new comment to the database
                    db.Comments.Add(newComment);
                    // Save the changes to the database
                    db.SaveChanges();
                    // Return a 201 Created status with the new comment's URI and data
                    return Results.Created($"/comments/{newComment.Id}", newComment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Return a 400 Bad Request status if there is a concurrency issue
                    return Results.BadRequest("An error occurred trying to add a new comment to the database");
                }
            });

            // Update an existing comment by ID
            app.MapPatch("/comments/{id}", (SportsplexDbContext db, int id, Comment comment) =>
            {
                // Find the comment to update by ID
                Comment commentToUpdate = db.Comments.FirstOrDefault(c => c.Id == id);
                // Return a 404 Not Found status if the comment does not exist
                if (commentToUpdate == null)
                {
                    return Results.NotFound("Comment not found");
                }
                // Update the comment's content
                commentToUpdate.Content = comment.Content;
                // Save the changes to the database
                db.SaveChanges();
                // Return the updated comment with a 200 OK status
                return Results.Ok(commentToUpdate);
            });

            // Delete an existing comment by ID
            app.MapDelete("/comments/{id}", (SportsplexDbContext db, int id) =>
            {
                // Find the comment to delete by ID
                var commentToDelete = db.Comments.FirstOrDefault(c => c.Id == id);

                // Return a 404 Not Found status if the comment does not exist
                if (commentToDelete == null)
                {
                    return Results.NotFound("No comment with matching id");
                }

                // Remove the comment from the database
                db.Comments.Remove(commentToDelete);
                // Save the changes to the database
                db.SaveChanges();
                // Return a 200 OK status with a deletion confirmation message
                return Results.Ok("Comment deleted");
            });
        }
    }
}