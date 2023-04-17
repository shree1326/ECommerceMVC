using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Painting>().HasKey(am => new
            {
                am.ArtistId,
                am.PaintingId
            });

            modelBuilder.Entity<Artist_Painting>().HasOne(m => m.Painting).WithMany(am => am.Artists_Paintings).HasForeignKey(m => m.PaintingId);
            modelBuilder.Entity<Artist_Painting>().HasOne(m => m.Artist).WithMany(am => am.Artists_Paintings).HasForeignKey(m => m.ArtistId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<Artist_Painting> Artists_Paintings { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<FundRaiser> FundRaisers { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
