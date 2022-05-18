using Microsoft.EntityFrameworkCore;

namespace OOP9.DB
{
    internal class UserContext : DbContext
    {
        public DbSet<User> PhoneBooks { get; set; }

        public UserContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Phones;Username=postgres;Password=Argus32219");
        }
    }
}
