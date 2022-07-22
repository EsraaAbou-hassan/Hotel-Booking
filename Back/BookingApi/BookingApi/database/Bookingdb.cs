using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookingApi.Models;
using BookingApi.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace BookingApi.database
{
    public class Bookingdb : IdentityDbContext<User>
    {
        
        public  IConfiguration Configuration { get; }
        RoleServices roleServices = new RoleServices();
        public Bookingdb(DbContextOptions<Bookingdb> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingRoomToUser>().HasKey(sc => new { sc.UserId, sc.RoomId,sc.HotelId});
            modelBuilder.Entity<RoomsInHotel>().HasKey(sc => new { sc.HotelId, sc.RoomId });
            modelBuilder.Entity<HotelFeatures>().HasKey(sc => new { sc.FeatureId, sc.HotelId });
            modelBuilder.Entity<RoomService>().HasKey(sc => new { sc.ServiceId, sc.RoomId });

            


        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(option =>
            {

                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;


                options.TokenValidationParameters =
                new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValiedAudience"],
                    IssuerSigningKey =
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecrurityKey"]))

                };

            }
    );

            roleServices.CreatedRole_User();

        }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RoomsInHotel> RoomsInHotel { get; set; }
        public virtual DbSet<BookingRoomToUser> BookingRoomToUser { get; set; }
        public virtual DbSet<RoomImages> RoomImages { get; set; }
        public virtual DbSet<HoteImages> HoteImages { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<HotelFeatures> HotelFeatures { get; set; }

        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<RoomService>RoomServices { get; set; }

    }
}
