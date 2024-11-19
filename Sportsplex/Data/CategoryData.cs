using Sportsplex.Models;

namespace Sportsplex.Data
{
    public class CategoryData
    {
        public static List<Category> Categories =
        [
            new() { Id = 1, Name = "Baseball" },
            new() { Id = 2, Name = "Soccer" },
            new() { Id = 3, Name = "Swimming" },
            new() { Id = 4, Name = "Football" },
            new() { Id = 5, Name = "Basketball" }
        ];
    }
}