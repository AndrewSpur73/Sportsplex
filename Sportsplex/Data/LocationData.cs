using Sportsplex.Models;

namespace Sportsplex.Data
{
    public class LocationData
    {
        public static List<Location> Locations =
        [
            new() { Id = 1, Name = "Hendersonville" },
            new() { Id = 2, Name = "Gallatin" },
            new() { Id = 3, Name = "Nashville" },
            new() { Id = 4, Name = "Portland" },
            new() { Id = 5, Name = "Murfreesboro" }
        ];
    }
}