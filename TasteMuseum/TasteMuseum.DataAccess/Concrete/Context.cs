using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasteMuseum.Entity.Concreate;
using TasteMuseum.Entity.Concrete;

namespace TasteMuseum.DataAccess.Concreate
{
    public class Context : IdentityDbContext<User,UserRole, int>
    {
        public Context() { }
        public Context(DbContextOptions options ): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TasteMuseum;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<FoodComment> FoodComments { get; set; }
        public DbSet<RestaurantComment> RestaurantComments { get; set; }
        public DbSet<RestaurantFood> RestaurantFoods{ get; set; }
        public DbSet<Reservation> Reservations{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RestaurantFood>()
                .HasKey(rf => new { rf.RestaurantId, rf.FoodId });

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.RestaurantFood)
                .WithOne(rf => rf.Restaurant)
                .HasForeignKey(rf => rf.RestaurantId);

            modelBuilder.Entity<Food>()
                .HasMany(f => f.RestaurantFood)
                .WithOne(rf => rf.Food)
                .HasForeignKey(rf => rf.FoodId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.RestaurantComments)
                .WithOne(rc => rc.User)
                .HasForeignKey(rc => rc.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.FoodComments)
                .WithOne(fc => fc.User)
                .HasForeignKey(fc => fc.UserId);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.RestaurantComments)
                .WithOne(rc => rc.Restaurant)
                .HasForeignKey(rc => rc.RestaurantId);

            modelBuilder.Entity<Food>()
                .HasMany(f => f.FoodComments)
                .WithOne(fc => fc.Food)
                .HasForeignKey(fc => fc.FoodId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Restaurant)
                .WithMany(re => re.Reservations)
                .HasForeignKey(r => r.RestaurantId);
        }
    }
}
