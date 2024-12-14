using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sportsplex.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Rsvps = table.Column<int>(type: "integer", nullable: false),
                    ReservedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookingId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBooking",
                columns: table => new
                {
                    BookerId = table.Column<int>(type: "integer", nullable: false),
                    VenueBookerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooking", x => new { x.BookerId, x.VenueBookerId });
                    table.ForeignKey(
                        name: "FK_UserBooking_Bookings_VenueBookerId",
                        column: x => x.VenueBookerId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBooking_Users_BookerId",
                        column: x => x.BookerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Baseball" },
                    { 2, "Soccer" },
                    { 3, "Swimming" },
                    { 4, "Football" },
                    { 5, "Basketball" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hendersonville" },
                    { 2, "Gallatin" },
                    { 3, "Nashville" },
                    { 4, "Portland" },
                    { 5, "Murfreesboro" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Image", "Uid", "UserName" },
                values: new object[,]
                {
                    { 1, "noahcurryallenpa@gmail.com", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpYf1NgPAHFUAUb_EeeJ6ZS-l_VxhwiPD_1A&s", "fgikJy5FMVXz3M8t5DkBSzUp64i2", "Noah" },
                    { 2, "deramust@gmail.com", "https://store.nana.co/_next/image?url=https%3A%2F%2Fcdn.nana.sa%2Fcatalog%2Flarge%2F8%2F3%2F5%2Fd%2F835d1df68bafe50d5c93e5354af0a33785bc7cac_8697439302229.jpg&w=1200&q=75", "MJ1mbp0Gm1dnXYqECtMh3PH5dHy2", "Toren" },
                    { 3, "Mrthincrisp@example.com", "https://m.media-amazon.com/images/I/814UidWgKOL.jpg", "ghi789", "CoolGuyDerek" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "LocationId", "Name", "OwnerId", "ReservedDate", "Rsvps" },
                values: new object[,]
                {
                    { 1, 1, "Looking for a well-maintained baseball field for your team’s practice, friendly matches, or community events? Our well-maintained baseball field is just the right size for youth teams, recreational leagues, or small group games.", "https://mainstreetmediatn.com/wp-content/uploads/images/2020-08-03/dd4fab6c064324561e49e8a44eaa6afc.jpg", 1, "Drakes Creek Park, Baseball Field 1", 1, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 },
                    { 2, 2, "Need a soccer field for your team’s practice sessions, friendly matches, or local events? Our soccer field is ideal for youth teams, recreational leagues, or casual play with friends.", "https://themotzgroup.com/wp-content/webpc-passthru.php?src=https://themotzgroup.com/wp-content/uploads/2022/08/Russell-Creek-Park-Complete-5.2-7.jpg&nocache=1", 1, "Drakes Creek Park, Soccer Field 1", 1, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 },
                    { 3, 3, "Make a splash with our pool rental! Whether you're planning a private party, hosting swim lessons, or just looking for a refreshing way to spend the day, our clean and well-maintained pool is ready for you.", "https://swimswam.com/wp-content/uploads/2017/05/Stock-RCC-pool-4.jpg", 3, "Nashville Pool, Pool 1", 1, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 },
                    { 4, 4, "Get your team together and hit the gridiron with our football field rental. Whether it’s practice, a scrimmage, or a community event, our well-kept field is ready for action.", "https://www.sunshineofficials.com/wp-content/uploads/2017/06/youth-field.jpg", 3, "Gallatin Football Complex", 2, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 },
                    { 5, 5, "Our basketball court rental is perfect for players of all skill levels. Whether you're running drills, organizing a pickup game, or hosting a small tournament, this court provides a professional and comfortable space for play.", "https://d2rzw8waxoxhv2.cloudfront.net/facilities/large/1ce7836979045d923802/1650980224494-333-243.jpeg", 4, "Portland Park, Basketball Court 1", 2, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 120 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookingId", "Content", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I love Baseball", 1 },
                    { 2, 2, "I love Soccer", 1 },
                    { 3, 3, "I love Swimming", 2 },
                    { 4, 4, "I love Football", 3 },
                    { 5, 5, "I love Basketball", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CategoryId",
                table: "Bookings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_LocationId",
                table: "Bookings",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OwnerId",
                table: "Bookings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookingId",
                table: "Comments",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooking_VenueBookerId",
                table: "UserBooking",
                column: "VenueBookerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "UserBooking");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
