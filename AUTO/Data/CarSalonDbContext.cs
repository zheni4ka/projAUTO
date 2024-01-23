using Microsoft.EntityFrameworkCore;
using AUTO.Data.Entities;
namespace AUTO.Data
{
    public class CarSalonDbContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Company> Companies { get; set; }

        public CarSalonDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Auto>().HasData(new[]
            {
                new Auto(){Id = 1, Mark="Mazda", Model="RX-7", Price=18000, Speed=240},
                new Auto(){Id = 2, Mark="Mazda", Model="RX-8", Price=20000, Speed=270},
                new Auto(){Id = 3, Mark="Dodge", Model="Challenger SRT Demon", Price=100000, Speed=380},
                new Auto(){Id = 4, Mark="Nissan", Model="240sx", Price=14000, Speed=210},
                new Auto(){Id = 5, Mark="Nissan", Model="350z", Price=19000, Speed=230}
            });

            modelBuilder.Entity<Company>().HasData(new[]
            {
                new Company(){Id = 1, Name="Mazda Motor Corporation", Address="Aki District, Hiroshima Prefecture, Japan.", Email="mazda@gmail.com"},
                new Company(){Id = 2, Name="Nissan Motor Co., Ltd.", Address=" Nishi-ku, Yokohama, Japan.", Email="nissan@gmail.com"},
                new Company(){Id = 3, Name="Dodge", Address="Obern-Hills, Michigan, USA", Email="dodge@gmail.com"}
            });
        }
    }
}
