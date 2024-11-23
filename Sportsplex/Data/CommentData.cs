using Sportsplex.Models;

namespace Sportsplex.Data
{
    public class CommentData
    {
        public static List<Comment> Comments =
        [
            new() { Id = 1, AuthorId = 1, BookingId = 1, Content = "I love Baseball" },
            new() { Id = 2, AuthorId = 1, BookingId = 2, Content = "I love Soccer" },
            new() { Id = 3, AuthorId = 2, BookingId = 3, Content = "I love Swimming" },
            new() { Id = 4, AuthorId = 3, BookingId = 4, Content = "I love Football" },
            new() { Id = 5, AuthorId = 2, BookingId = 5, Content = "I love Basketball" }
        ];
    }
}