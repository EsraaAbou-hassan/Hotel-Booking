using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookingApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BookingApi.database
{
    public class Bookingdb : IdentityDbContext<User>
    {
        public Bookingdb()
        {
        }

        public Bookingdb(DbContextOptions<Bookingdb> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingRoomToUser>().HasKey(sc => new { sc.UserId, sc.RoomId });
            modelBuilder.Entity<RoomAvailabe>().HasKey(sc => new { sc.HotelId, sc.RoomId });

        }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RoomAvailabe>  RoomAvailabes { get; set; }
        public virtual DbSet<BookingRoomToUser> BookingRoomToUser { get; set; }
        public virtual DbSet<RoomImages> RoomImages { get; set; }
        public virtual DbSet<HoteImages> HoteImages { get; set; }

    }
}
