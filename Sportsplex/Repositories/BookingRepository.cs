using Microsoft.EntityFrameworkCore;
using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly SportsplexDbContext _context;

        public BookingRepository(SportsplexDbContext context)
        {
            _context = context;
        }

        //Get all Bookings
        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            {

                var Booking = await _context.Bookings
                    .ToListAsync();

                if (Booking == null)
                {
                    return null;
                }

                return Booking;

            };
        }


        //Create a Booking
        public async Task<Booking> CreateBookingAsync(CreateBookingDTO BookingDTO)
        {

            var newBooking = new Booking
            {
                OwnerId = BookingDTO.OwnerId,
                Image = BookingDTO.Image,
                Facility = BookingDTO.Facility,
                SportSpace = BookingDTO.SportSpace,
                Description = BookingDTO.Description,
                Rsvps = BookingDTO.Rsvps,
                ReservedDate = BookingDTO.ReservedDate,
                CategoryId = BookingDTO.CategoryId,

            };

            try
            {
                _context.Bookings.Add(newBooking);
                await _context.SaveChangesAsync();
                return newBooking;
            }
            catch (DbUpdateException)
            {
                return null;
            }

        }


        //Update a Booking
        public async Task<Booking> UpdateBookingAsync(int id, UpdateBookingDTO BookingDTO)
        {
            var BookingToUpdate = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);

            if (BookingToUpdate == null)
            {
                return null;
            }

            BookingToUpdate.Image = BookingDTO.Image;
            BookingToUpdate.Facility = BookingDTO.Facility;
            BookingToUpdate.SportSpace = BookingDTO.SportSpace;
            BookingToUpdate.Description = BookingDTO.Description;
            BookingToUpdate.ReservedDate = BookingDTO.ReservedDate;
            BookingToUpdate.CategoryId = BookingDTO.CategoryId;

            try
            {
                await _context.SaveChangesAsync();
                return BookingToUpdate;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
        }

        //Delete a Booking
        public async Task<Booking> DeleteBookingAsync(int id)
        {

            var Booking = await _context.Bookings
                    .Include(b => b.Booker)
                    .FirstOrDefaultAsync(b => b.Id == id);

            if (Booking == null)
            {
                return null;
            }

            // Remove all associations with the attendees
            Booking.Booker.Clear();

            // Remove the Booking itself
            _context.Bookings.Remove(Booking);
            _context.SaveChanges();

            return Booking;

        }

        //Get a single Booking
        public async Task<Booking> GetBookingByIdAsync(int id)
        {

            var singleBooking = await _context.Bookings
            .Include(b => b.OwnerId)
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

            try
            {
                await _context.SaveChangesAsync();
                return singleBooking;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }

        }
    }
}
