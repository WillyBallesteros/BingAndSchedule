using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LocationsApiDbContext : DbContext, ILocationsApiDbContext
    {
        public LocationsApiDbContext()
        {
        }

        public LocationsApiDbContext(DbContextOptions<LocationsApiDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=localhost\sqlexpress; 
                Initial Catalog=LocationsApi; Integrated Security=True")
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(m => m.Schedules)
                .WithOne(m => m.Location)
                .HasForeignKey(m => m.LocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);            
        }

        public DbSet<Location>? Locations { get; set; }
        public DbSet<Schedule>? Schedules { get; set; }
    }
}