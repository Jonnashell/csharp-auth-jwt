using api_cinema_challenge.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace api_cinema_challenge.Data
{
    public class CinemaContext : IdentityUserContext<ApplicationUser>
    {
        private string _connectionString;
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customers
            Customer customer = new Customer
            {
                Id = 1,
                Name = "Jonatan",
                Email = "jonnabr@hotmail.com",
                Phone = "+4793277670",
                CreatedAt = new DateTime(2025, 01, 20, 12, 00, 00, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 01, 21, 15, 00, 00, DateTimeKind.Utc)
            };

            Customer customer2 = new Customer
            {
                Id = 2,
                Name = "Isabel",
                Email = "Isabel@hotmail.com",
                Phone = "+4792088620",
                CreatedAt = new DateTime(2025, 01, 20, 12, 00, 00, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 01, 21, 15, 00, 00, DateTimeKind.Utc)
            };

            Customer customer3 = new Customer
            {
                Id = 3,
                Name = "Marius",
                Email = "marius@hotmail.com",
                Phone = "+4798765432",
                CreatedAt = new DateTime(2025, 01, 19, 12, 00, 00, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 01, 21, 17, 00, 00, DateTimeKind.Utc)
            };

            Customer customer4 = new Customer
            {
                Id = 4,
                Name = "Emma",
                Email = "emma@hotmail.com",
                Phone = "+4791234567",
                CreatedAt = new DateTime(2025, 01, 18, 12, 00, 00, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 01, 21, 18, 00, 00, DateTimeKind.Utc)
            };

            modelBuilder.Entity<Customer>().HasData([customer, customer2, customer3, customer4]);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
