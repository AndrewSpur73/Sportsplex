using Microsoft.EntityFrameworkCore;
using Sportsplex.DTO;
using Sportsplex.Models;

namespace Sportsplex.API
{
    public class CommentAPI
    {
        public static void Map(WebApplication app)
        {
            //Get all of a Post's comments
            app.MapGet("/comments/bookings/{id}", async (SportsplexDbContext db, int id) =>
            {
                var comments = await db.Comments.Where(c => c.BookingId == id).Include(c => c.User).ToListAsync();

                if (comments == null)
                {
                    return Results.NotFound("comment is null");
                }

                return Results.Ok(comments);

            });

            //Create Comment
            app.MapPost("/comments", (SportsplexDbContext db, CreateCommentDTO newCommentDTO) =>
            {
                var newComment = new Comment
                {
                    Content = newCommentDTO.Content,
                    AuthorId = newCommentDTO.AuthorId,
                    BookingId = newCommentDTO.BookingId,
                };

                try
                {
                    db.Comments.Add(newComment);
                    db.SaveChanges();
                    return Results.Created($"/comments/{newComment.Id}", newComment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Results.BadRequest("An error occurred trying to add a new comment to the database");
                }
            });

            //Update Comment
            app.MapPatch("/comments/{id}", (SportsplexDbContext db, int id, Comment comment) =>
            {
                Comment commentToUpdate = db.Comments.FirstOrDefault(c => c.Id == id);
                if (commentToUpdate == null)
                {
                    return Results.NotFound("Comment not found");
                }
                commentToUpdate.Content = comment.Content;
                db.SaveChanges();
                return Results.Ok(commentToUpdate);
            });

            // Delete Comment
            app.MapDelete("/comments/{id}", (SportsplexDbContext db, int id) =>
            {
                var commentToDelete = db.Comments.FirstOrDefault(c => c.Id == id);

                if (commentToDelete == null)
                {
                    return Results.NotFound("No comment with matching id");
                }

                db.Comments.Remove(commentToDelete);
                db.SaveChanges();
                return Results.Ok("Comment deleted");
            });
        }
    }
}