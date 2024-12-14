namespace Sportsplex.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Rsvps { get; set; }
        public DateTime ReservedDate { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<User>? Booker { get; set; }
        public User? User { get; set; }

        public string ReservedDateFormatted => ReservedDate.ToString("yyyy-MM-dd");
    }

}