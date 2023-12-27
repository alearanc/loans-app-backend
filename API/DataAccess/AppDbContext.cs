using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Thing> Things { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thing>()
                .HasOne<Category>()
                .WithMany(c => c.Things)
                .IsRequired();

            modelBuilder.Entity<Loan>()
                .HasOne<Thing>()
                .WithMany(t => t.Loans)
                .IsRequired();

            modelBuilder.Entity<Loan>()
                .HasOne<Person>()
                .WithMany(p => p.Loans)
                .IsRequired();

            modelBuilder.Entity<Category>(c =>
            {
                c.HasData(
                    new Category()
                    {
                        Id = 1,
                        Description = "libros",
                        CreationDate = new DateOnly(1997, 01, 22)
                    },
                    new Category()
                    {
                        Id = 2,
                        Description = "computación",
                        CreationDate = new DateOnly(1997, 01, 22)
                    },
                    new Category()
                    {
                        Id = 3,
                        Description = "audio",
                        CreationDate = new DateOnly(1997, 01, 22)
                    },
                    new Category()
                    {
                        Id = 4,
                        Description = "indumentaria",
                        CreationDate = new DateOnly(1997, 01, 22)
                    },
                    new Category()
                    {
                        Id = 5,
                        Description = "varios",
                        CreationDate = new DateOnly(1997, 01, 22)
                    });
            });
        }
    }
}
