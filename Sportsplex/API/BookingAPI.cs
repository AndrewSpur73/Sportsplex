using Sportsplex.DTO;
using Sportsplex.Models;
using Microsoft.EntityFrameworkCore;
using Sportsplex;

namespace Sportsplex.API
{
    public class BookingAPI
    {
        public static async void Map(WebApplication app)
        {
            //Get All Bookings
            app.MapGet("/bookings", async (SportsplexDbContext db) =>
            {

                var booking = await db.Bookings
                .Include(b => b.Location)
                .Include(b => b.Category)
                .Include(b => b.Comments)
                .ToListAsync();

                return Results.Ok(booking);

            });

            //Get a User's Bookings
            app.MapGet("/bookings/user/{id}", async (SportsplexDbContext db, int id) =>
            {

                var userBookings = await db.Bookings.Where(b => b.OwnerId == id)
                .Include(b => b.Location)
                .Include(b => b.Category)
                .Include(b => b.Comments)
                .ToListAsync();

                if (userBookings == null)
                {
                    return Results.NotFound("No bookings found for user.");
                }

                return Results.Ok(userBookings);

            });

            //Get a Single Booking
            app.MapGet("bookings/{id}", async (SportsplexDbContext db, int id) =>
            {

                var singleBooking = await db.Bookings
                .Include(b => b.User)
                .Include(b => b.Category)
                .Include(b => b.Location)
                .Include(b => b.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(b => b.Id == id);

                if (singleBooking == null)
                {
                    return Results.NotFound("No booking found.");
                }

                return Results.Ok(singleBooking);
            });

            //Create a new booking
            app.MapPost("/bookings", async (CreateBookingDTO bookingDTO, SportsplexDbContext db) =>
            {
                var newBooking = new Booking
                {
                    OwnerId = bookingDTO.OwnerId,
                    Image = bookingDTO.Image,
                    Name = bookingDTO.Name,
                    Description = bookingDTO.Description,
                    Rsvps = bookingDTO.Rsvps,
                    ReservedDate = bookingDTO.ReservedDate,
                    CategoryId = bookingDTO.CategoryId,
                    LocationId = bookingDTO.LocationId,
                };

                try
                {
                    db.Bookings.Add(newBooking);
                    await db.SaveChangesAsync();
                    return Results.Created($"/bookings/{newBooking.Id}", newBooking);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Unable to create booking");
                }


            });

            //Update a Booking
            app.MapPut("/bookings/{id}", async (int id, UpdateBookingDTO bookingDTO, SportsplexDbContext db) =>
            {
                var bookingToUpdate = await db.Bookings.FirstOrDefaultAsync(b => b.Id == id);

                if (bookingToUpdate == null)
                {
                    return Results.NotFound("No booking found.");
                }

                bookingToUpdate.Image = bookingDTO.Image;
                bookingToUpdate.Name = bookingDTO.Name;
                bookingToUpdate.Description = bookingDTO.Description;
                bookingToUpdate.ReservedDate = bookingDTO.ReservedDate;
                bookingToUpdate.CategoryId = bookingDTO.CategoryId;
                bookingToUpdate.LocationId = bookingDTO.LocationId;
                try
                {
                    await db.SaveChangesAsync();
                    return Results.Ok(bookingToUpdate);
                }
                catch (DbUpdateException ex)
                {
                    return Results.BadRequest($"Failed to update booking: {ex.Message}");
                }

            });

            //Delete a booking
            app.MapDelete("bookings/{id}", async (SportsplexDbContext db, int id) =>
            {
                var booking = await db.Bookings
                    .Include(b => b.Booker)
                    .FirstOrDefaultAsync(b => b.Id == id);

                if (booking == null)
                {
                    return Results.NotFound("Booking not found.");
                }

                // Remove all associations with the attendees
                booking.Booker.Clear();

                // Remove the show itself
                db.Bookings.Remove(booking);
                db.SaveChanges();

                return Results.Ok("Booking and its associations deleted successfully.");
            });

            //RSVP a booking
            app.MapPost("bookings/attend", async (SportsplexDbContext db, int bookingId, int userId) =>
            {

                var booking = await db.Bookings
                    .Include(b => b.Booker)  // Include the bookers to manage the relationship
                    .FirstOrDefaultAsync(b => b.Id == bookingId);

                if (booking == null)
                {
                    return Results.NotFound("Booking not found.");
                }

                var user = await db.Users
                    .Include(u => u.VenueBooker)  // Include VenueBooker to manage the relationship
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }

                // Check if the user is already attending the show
                if (booking.Booker.Any(b => b.Id == userId))
                {
                    return Results.BadRequest("User already RSVPed to this booking.");
                }

                // Add the user to the show's bookers
                booking.Booker.Add(user);

                await db.SaveChangesAsync();

                return Results.Ok("RSVP successful.");

            });

            //Get a User's bookings
            app.MapGet("/bookings/attend/{userId}", async (SportsplexDbContext db, int userId) =>
            {

                var bookings = await db.Bookings
                    .Where(b => b.Booker.Any(u => u.Id == userId))
                    .ToListAsync();

                return Results.Ok(bookings);

            });

            //Delete an RSVP
            app.MapDelete("/bookings/attend/{userId}/{bookingId}", async (SportsplexDbContext db, int userId, int bookingId) =>
            {

                var booking = await db.Bookings
                .Include(b => b.Booker)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

                if (booking == null)
                {
                    return Results.NotFound($"Booking with ID {bookingId} not found.");
                }

                var user = booking.Booker.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return Results.NotFound($"User with ID {userId} has not booked {bookingId}.");
                }

                booking.Booker.Remove(user);
                await db.SaveChangesAsync();

                return Results.NoContent();

            });

            //Check if a booking is reserved
            app.MapGet("/bookings/{userId}/reserved/{bookingId}", async (SportsplexDbContext db, int userId, int bookingId) =>
            {

                var booking = await db.Bookings
                .Include(b => b.Booker)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

                if (booking == null)
                {
                    return Results.NotFound("Booking not found.");
                }

                var isReserved = booking.Booker.Any(b => b.Id == userId);

                return Results.Ok(isReserved);

            });
        }
    }
}