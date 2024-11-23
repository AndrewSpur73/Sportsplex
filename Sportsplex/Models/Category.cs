namespace Sportsplex.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Booking>? Booking { get; set; }
    }
}
