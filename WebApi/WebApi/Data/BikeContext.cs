using Microsoft.EntityFrameworkCore;

namespace WebApi.Data;


public class BikeContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Pedal> Pedals { get; set; }
    public DbSet<Break> Breaks { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Wheel> Wheels { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder
    //        .Entity<Bike>()
    //        .UseTptMappingStrategy();
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
    {
        opBuilder
            .UseSqlServer(@"Data Source=.;Initial Catalog=BikeFactory;Persist Security Info=False;User ID=sa; Password = Rvy2DU0LWN;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
    }
}