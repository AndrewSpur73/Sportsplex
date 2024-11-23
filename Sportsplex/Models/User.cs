namespace Sportsplex.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public List<Booking>? VenueBooker { get; set; }
        public List<Booking>? VenueOwner { get; set; }
        public List<Comment>? Comment { get; set; }
    }
}
