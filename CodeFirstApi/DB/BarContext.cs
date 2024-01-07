using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext> options) : base(options)
        {

        }

        public DbSet<Beer> Beers { get; set; } // Especificamos que la base de datos tiene una tabla Beers
        public DbSet<Brand> Brands { get; set; }

        /*
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            // En caso de que quisieramos cambiarle el nombre a las tablas. Aunque creo que no es necesario, eso ya se especifica en el DbSet
            modelBuilder.Entity<Beer>().ToTable("Beer"); // Especificams que la tabla Beers se llama Beer en la base de datos
            modelBuilder.Entity<Brand>().ToTable("Brand");
         }
         */
    }
}
