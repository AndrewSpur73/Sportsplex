using Sportsplex.Models;
using Sportsplex.DTO;

namespace Sportsplex.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking> CreateBookingAsync(CreateBookingDTO bookingDTO);
        Task<Booking> UpdateBookingAsync(int id, UpdateBookingDTO bookingDTO);
        Task<Booking> DeleteBookingAsync(int id);
        Task<Booking> GetBookingByIdAsync(int id);
    }
}
