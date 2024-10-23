using K8S.DriverAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace K8S.DriverAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Driver> Drivers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Driver[] drivers =
            [
                new() { FirstName = "Lewis", LastName = "Hamilton", DriverNumber = 44, DateOfBirth = new DateTime(1985, 1, 7) },
                new() { FirstName = "Max", LastName = "Verstappen", DriverNumber = 33, DateOfBirth = new DateTime(1997, 9, 30) },
                new() { FirstName = "Charles", LastName = "Leclerc", DriverNumber = 16, DateOfBirth = new DateTime(1997, 10, 16) }
            ];

            builder.Entity<Driver>().HasData(drivers);
        }
    }
}
