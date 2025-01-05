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
            // Endpoint to get all bookings
            app.MapGet("/bookings", async (SportsplexDbContext db) =>
            {
                // Retrieve all bookings including related location, category, and comments
                var booking = await db.Bookings
                .Include(b => b.Location)
                .Include(b => b.Category)
                .Include(b => b.Comments)
                .ToListAsync();

                // Return the bookings as an OK result
                return Results.Ok(booking);
            });

            // Endpoint to get bookings for a specific user by their ID
            app.MapGet("/bookings/user/{id}", async (SportsplexDbContext db, int id) =>
            {
                // Retrieve bookings where OwnerId matches the provided user ID
                var userBookings = await db.Bookings.Where(b => b.OwnerId == id)
                .Include(b => b.Location)
                .Include(b => b.Category)
                .Include(b => b.Comments)
                .ToListAsync();

                // Return NotFound if no bookings are found for the user
                if (userBookings == null)
                {
                    return Results.NotFound("No bookings found for user.");
                }

                // Return the user's bookings as an OK result
                return Results.Ok(userBookings);
            });

            // Endpoint to get a single booking by its ID
            app.MapGet("bookings/{id}", async (SportsplexDbContext db, int id) =>
            {
                // Retrieve the booking by ID including related user, category, location, and comments
                var singleBooking = await db.Bookings
                .Include(b => b.User)
                .Include(b => b.Category)
                .Include(b => b.Location)
                .Include(b => b.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(b => b.Id == id);

                // Return NotFound if the booking does not exist
                if (singleBooking == null)
                {
                    return Results.NotFound("No booking found.");
                }

                // Return the booking as an OK result
                return Results.Ok(singleBooking);
            });

            // Endpoint to create a new booking
            app.MapPost("/bookings", async (CreateBookingDTO bookingDTO, SportsplexDbContext db) =>
            {
                // Create a new booking from the provided data
                var newBooking = new Booking
                {
                    OwnerId = bookingDTO.OwnerId,
                    Image = bookingDTO.Image,
                    Facility = bookingDTO.Facility,
                    SportSpace = bookingDTO.SportSpace,
                    Description = bookingDTO.Description,
                    Rsvps = bookingDTO.Rsvps,
                    ReservedDate = bookingDTO.ReservedDate,
                    CategoryId = bookingDTO.CategoryId,
                    LocationId = bookingDTO.LocationId,
                };

                try
                {
                    // Add the new booking to the database and save changes
                    db.Bookings.Add(newBooking);
                    await db.SaveChangesAsync();
                    // Return a Created result with the new booking
                    return Results.Created($"/bookings/{newBooking.Id}", newBooking);
                }
                catch (DbUpdateException)
                {
                    // Return BadRequest if there's an issue creating the booking
                    return Results.BadRequest("Unable to create booking");
                }
            });

            // Endpoint to update an existing booking
            app.MapPut("/bookings/{id}", async (int id, UpdateBookingDTO bookingDTO, SportsplexDbContext db) =>
            {
                // Find the booking to update by ID
                var bookingToUpdate = await db.Bookings.FirstOrDefaultAsync(b => b.Id == id);

                // Return NotFound if the booking does not exist
                if (bookingToUpdate == null)
                {
                    return Results.NotFound("No booking found.");
                }

                // Update the booking properties with the provided data
                bookingToUpdate.Image = bookingDTO.Image;
                bookingToUpdate.Facility = bookingDTO.Facility;
                bookingToUpdate.SportSpace = bookingDTO.SportSpace;
                bookingToUpdate.Description = bookingDTO.Description;
                bookingToUpdate.ReservedDate = bookingDTO.ReservedDate;
                bookingToUpdate.CategoryId = bookingDTO.CategoryId;
                bookingToUpdate.LocationId = bookingDTO.LocationId;
                try
                {
                    // Save the updated booking to the database
                    await db.SaveChangesAsync();
                    // Return the updated booking as an OK result
                    return Results.Ok(bookingToUpdate);
                }
                catch (DbUpdateException ex)
                {
                    // Return BadRequest if there's an issue updating the booking
                    return Results.BadRequest($"Failed to update booking: {ex.Message}");
                }
            });

            // Endpoint to delete a booking by its ID
            app.MapDelete("bookings/{id}", async (SportsplexDbContext db, int id) =>
            {
                // Find the booking to delete by ID, including related bookers
                var booking = await db.Bookings
                    .Include(b => b.Booker)
                    .FirstOrDefaultAsync(b => b.Id == id);

                // Return NotFound if the booking does not exist
                if (booking == null)
                {
                    return Results.NotFound("Booking not found.");
                }

                // Clear all associations with the bookers
                booking.Booker.Clear();

                // Remove the booking from the database
                db.Bookings.Remove(booking);
                db.SaveChanges();

                // Return an OK result confirming deletion
                return Results.Ok("Booking and its associations deleted successfully.");
            });

            // Endpoint to RSVP to a booking
            app.MapPost("bookings/attend", async (SportsplexDbContext db, int bookingId, int userId) =>
            {
                // Find the booking to RSVP to by ID, including related bookers
                var booking = await db.Bookings
                    .Include(b => b.Booker)
                    .FirstOrDefaultAsync(b => b.Id == bookingId);

                // Return NotFound if the booking does not exist
                if (booking == null)
                {
                    return Results.NotFound("Booking not found.");
                }

                // Find the user by ID, including related venue bookers
                var user = await db.Users
                    .Include(u => u.VenueBooker)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                // Return NotFound if the user does not exist
                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }

                // Return BadRequest if the user has already RSVPed
                if (booking.Booker.Any(b => b.Id == userId))
                {
                    return Results.BadRequest("User already RSVPed to this booking.");
                }

                // Add the user to the booking's bookers
                booking.Booker.Add(user);

                // Save changes to the database
                await db.SaveChangesAsync();

                // Return an OK result confirming the RSVP
                return Results.Ok("RSVP successful.");
            });

            // Endpoint to get bookings a user is attending
            app.MapGet("/bookings/attend/{userId}", async (SportsplexDbContext db, int userId) =>
            {
                // Retrieve bookings where the user is a booker
                var bookings = await db.Bookings
                    .Where(b => b.Booker.Any(u => u.Id == userId))
                    .ToListAsync();

                // Return the bookings as an OK result
                return Results.Ok(bookings);
            });

            // Endpoint to delete an RSVP
            app.MapDelete("/bookings/attend/{userId}/{bookingId}", async (SportsplexDbContext db, int userId, int bookingId) =>
            {
                // Find the booking by ID, including related bookers
                var booking = await db.Bookings
                .Include(b => b.Booker)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

                // Return NotFound if the booking does not exist
                if (booking == null)
                {
                    return Results.NotFound($"Booking with ID {bookingId} not found.");
                }

                // Find the user in the booking's bookers
                var user = booking.Booker.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return Results.NotFound($"User with ID {userId} has not booked {bookingId}.");
                }

                // Remove the user from the booking's bookers
                booking.Booker.Remove(user);
                // Save changes to the database
                await db.SaveChangesAsync();

                // Return NoContent to indicate successful deletion
                return Results.NoContent();
            });

            // Endpoint to check if a booking is reserved by a user
            app.MapGet("/bookings/{userId}/reserved/{bookingId}", async (SportsplexDbContext db, int userId, int bookingId) =>
            {
                // Find the booking by ID, including related bookers
                var booking = await db.Bookings
                .Include(b => b.Booker)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

                // Return NotFound if the booking does not exist
                if (booking == null)
                {
                    return Results.NotFound("Booking not found.");
                }

                // Check if the user is among the booking's bookers
                var isReserved = booking.Booker.Any(b => b.Id == userId);

                // Return an OK result with the reservation status
                return Results.Ok(isReserved);
            });
        }
    }
}