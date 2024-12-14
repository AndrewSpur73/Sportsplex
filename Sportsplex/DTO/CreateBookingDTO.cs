namespace Sportsplex.DTO
{
    public class CreateBookingDTO
    {
        public int OwnerId { get; set; }
        public string? Image { get; set; }
        public string? Facility { get; set; }
        public string? SportSpace { get; set; }
        public string? Description { get; set; }
        public int Rsvps { get; set; } = 0;
        public DateTime ReservedDate { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public int CommentId { get; set; }
        public string DateFormat => ReservedDate.ToString("MM/dd/yyyy");
    }
}
