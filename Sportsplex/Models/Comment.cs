namespace Sportsplex.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public List<Booking>? Booking { get; set; }
    }
}
