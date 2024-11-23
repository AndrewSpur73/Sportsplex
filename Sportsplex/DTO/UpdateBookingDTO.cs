namespace Sportsplex.DTO
{
    public class UpdateBookingDTO
    {
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ReservedDate { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public int CommentId { get; set; }
        public string DateFormat => ReservedDate.ToString("MM/dd/yyyy");
    }
}
