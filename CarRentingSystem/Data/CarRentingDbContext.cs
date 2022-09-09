using CarRentingSystem.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentingSystem.Data
{
    public class CarRentingDbContext : IdentityDbContext
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; init; }
        public DbSet<Review> Reviews { get; init; }
    }
}
