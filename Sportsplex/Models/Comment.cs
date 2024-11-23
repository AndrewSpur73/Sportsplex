using Microsoft.Extensions.Hosting;

namespace Sportsplex.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookingId { get; set; }
        public string? Content { get; set; }
        public User? User { get; set; }
        public Booking? Booking { get; set; }
    }
}
