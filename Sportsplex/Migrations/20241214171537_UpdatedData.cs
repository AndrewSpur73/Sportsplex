using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sportsplex.Migrations
{
    public partial class UpdatedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Lacrosse" },
                    { 7, "Rugby" },
                    { 8, "Pickleball" },
                    { 9, "Volleyball" },
                    { 10, "Tennis" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Brentwood" },
                    { 7, "Clarksville" },
                    { 8, "Franklin" },
                    { 9, "Nolensville" },
                    { 10, "Mount Juliet" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CategoryId", "Description", "Facility", "Image", "LocationId", "OwnerId", "ReservedDate", "Rsvps", "SportSpace" },
                values: new object[,]
                {
                    { 6, 10, "Enjoy a game of tennis on our top-quality court, perfect for singles or doubles matches.", "Sunset Sports Complex", "https://brightspotcdn.byu.edu/dims4/default/f6d0944/2147483647/strip/true/crop/4864x3648+304+0/resize/620x465!/quality/90/?url=https%3A%2F%2Fbrigham-young-brightspot-us-east-2.s3.us-east-2.amazonaws.com%2Fdd%2F74%2F6e8ce64942358cee3fddc68cb3ba%2F1806-59-72.jpg", 2, 2, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, "Tennis Court 1" },
                    { 7, 6, "Host your next lacrosse practice or game on our regulation-size field with marked boundaries.", "Eagle Ridge Park", "https://turftank.com/wp-content/uploads/2022/12/turftank-dimensions-lacrosse-scaled.jpg", 3, 2, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, "Lacrosse Field 1" },
                    { 8, 7, "Experience a competitive rugby match on our well-maintained grass field with sideline seating.", "Highland Sports Arena", "https://www.kieferusa.com/wp-content/uploads/2015/09/rugby_Rhisso-Univ-Japan.jpg", 4, 3, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, "Rugby Field 1" },
                    { 9, 8, "Play a fast-paced game of pickleball on our professional court designed for all skill levels.", "Summit Recreation Center", "https://pickleballsuperstore.com/cdn/shop/articles/pickleball_court_dimensions_top_1147x.jpg?v=1642839067", 5, 3, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, "Pickleball Court 6" },
                    { 10, 4, "Host football games or training sessions on our full-size field with marked yard lines.", "Riverside Sports Grounds", "https://www.visitspacecoast.com/wp-content/uploads/2024/05/Viera-Regional-Park-Football-and-Lacross-Fields.jpg", 6, 1, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, "Football Field 2" },
                    { 11, 2, "Enjoy an exciting soccer match or practice session on our high-quality turf field.", "Hillside Park", "https://traceup.com/wp-content/uploads/2023/05/shutterstock_1068727478-e1685120725622.jpg", 7, 1, new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, "Soccer Field 2" },
                    { 12, 1, "Perfect for baseball tournaments, practices, and community events on our regulation field.", "Westwood Recreation Center", "https://www.gallatintn.gov/ImageRepository/Document?documentID=8738", 8, 2, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, "Baseball Field 2" },
                    { 13, 5, "Challenge friends or host tournaments on our outdoor basketball court with premium flooring.", "Downtown Sports Complex", "https://media.thetriibe.com/wp-content/uploads/2024/09/03122123/Basketball-Court-After.jpg", 9, 3, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, "Basketball Court 1" },
                    { 14, 3, "Enjoy lap swimming, lessons, or water aerobics in our temperature-controlled pool.", "Aqua Center", "https://havegoggleswilltravel.com/images/116/hamdan-sports-complex-training-pool-dubai-panoramic.jpg", 10, 3, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, "Swimming Pool 1" },
                    { 15, 10, "Play beach  volleyball on our sand-filled court.", "Seaside Sports Arena", "https://www.sportswestco.com/wp-content/uploads/Montecito-QAD-Corporation-1.jpg", 8, 3, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, "Volleyball Court 1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
