using Sportsplex.Models;

namespace Sportsplex.Data
{
    public class ShowData
    {

        public static List<Booking> Bookings =
        [
            new() { Id = 1, OwnerId = 1, Image = "https://mainstreetmediatn.com/wp-content/uploads/images/2020-08-03/dd4fab6c064324561e49e8a44eaa6afc.jpg", Name = "Drakes Creek Park, Baseball Field 1", Description = "Looking for a well-maintained baseball field for your team’s practice, friendly matches, or community events? Our well-maintained baseball field is just the right size for youth teams, recreational leagues, or small group games.", Rsvps = 120, ReservedDate = new DateTime(2024, 10, 20), CategoryId = 1, LocationId = 1, CommentId = 1 },
            new() { Id = 2, OwnerId = 1, Image = "https://themotzgroup.com/wp-content/webpc-passthru.php?src=https://themotzgroup.com/wp-content/uploads/2022/08/Russell-Creek-Park-Complete-5.2-7.jpg&nocache=1", Name = "Drakes Creek Park, Soccer Field 1", Description = "Need a soccer field for your team’s practice sessions, friendly matches, or local events? Our soccer field is ideal for youth teams, recreational leagues, or casual play with friends.", Rsvps = 120, ReservedDate = new DateTime(2024, 10, 20), CategoryId = 2, LocationId = 1, CommentId = 2 },
            new() { Id = 3, OwnerId = 1, Image = "https://swimswam.com/wp-content/uploads/2017/05/Stock-RCC-pool-4.jpg", Name = "Nashville Pool, Pool 1", Description = "Make a splash with our pool rental! Whether you're planning a private party, hosting swim lessons, or just looking for a refreshing way to spend the day, our clean and well-maintained pool is ready for you.", Rsvps = 120, ReservedDate = new DateTime(2024, 10, 20), CategoryId = 3, LocationId = 3, CommentId = 3 },
            new() { Id = 4, OwnerId = 2, Image = "https://www.sunshineofficials.com/wp-content/uploads/2017/06/youth-field.jpg", Name = "Gallatin Football Complex", Description = "Get your team together and hit the gridiron with our football field rental. Whether it’s practice, a scrimmage, or a community event, our well-kept field is ready for action.", Rsvps = 120, ReservedDate = new DateTime(2024, 10, 20), CategoryId = 4, LocationId = 3, CommentId = 4 },
            new() { Id = 5, OwnerId = 2, Image = "https://d2rzw8waxoxhv2.cloudfront.net/facilities/large/1ce7836979045d923802/1650980224494-333-243.jpeg", Name = "Portland Park, Basketball Court 1", Description = "Our basketball court rental is perfect for players of all skill levels. Whether you're running drills, organizing a pickup game, or hosting a small tournament, this court provides a professional and comfortable space for play.", Rsvps = 120, ReservedDate = new DateTime(2024, 10, 20), CategoryId = 5, LocationId = 4, CommentId = 5 },
        ];
    }
}
