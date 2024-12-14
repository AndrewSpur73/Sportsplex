using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Sportsplex.Data;
using Sportsplex.Models;

namespace Sportsplex
{
    public class SportsplexDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public SportsplexDbContext(DbContextOptions<SportsplexDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<Category>().HasData(CategoryData.Categories);
            modelBuilder.Entity<Booking>().HasData(BookingData.Bookings);
            modelBuilder.Entity<Comment>().HasData(CommentData.Comments);
            modelBuilder.Entity<Location>().HasData(LocationData.Locations);

            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Booker)
                .WithMany(u => u.VenueBooker)
                .UsingEntity(t => t.ToTable("UserBooking"));

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.VenueOwner)
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            //relationship between Booking and Comments, When a Booking is deleted any related Comments will be deleted as well. 
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.Comments)
                .WithOne(c => c.Booking)
                .HasForeignKey(c => c.BookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}