using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Services
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _BookingRepo;

        public BookingService(IBookingRepository BookingRepo)
        {
            _BookingRepo = BookingRepo;
        }

        public async Task<Booking> CreateBookingAsync(CreateBookingDTO BookingDTO)
        {
            return await _BookingRepo.CreateBookingAsync(BookingDTO);
        }

        public async Task<Booking> DeleteBookingAsync(int id)
        {
            return await _BookingRepo.DeleteBookingAsync(id);
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _BookingRepo.GetAllBookingsAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            var singleBooking = _BookingRepo.GetBookingByIdAsync(id);

            if (singleBooking == null)
            {
                throw new ArgumentException("Booking not found.");
            }

            return await _BookingRepo.GetBookingByIdAsync(id);

        }

        public async Task<Booking> UpdateBookingAsync(int id, UpdateBookingDTO BookingDTO)
        {
            return await _BookingRepo.UpdateBookingAsync(id, BookingDTO);

        }
    }
}
