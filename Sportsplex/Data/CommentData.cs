using Sportsplex.Models;

namespace Sportsplex.Data
{
    public class CommentData
    {
        public static List<Comment> Comments =
        [
            new() { Id = 1, Content = "I love Baseball" },
            new() { Id = 2, Content = "I love Soccer" },
            new() { Id = 3, Content = "I love Swimming" },
            new() { Id = 4, Content = "I love Football" },
            new() { Id = 5, Content = "I love Basketball" }
        ];
    }
}