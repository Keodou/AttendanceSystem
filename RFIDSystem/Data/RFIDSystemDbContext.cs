using Microsoft.EntityFrameworkCore;

namespace RFIDSystem.Data
{
    public class RFIDSystemDbContext : DbContext
    {
        private readonly string _connectionString;

        public RFIDSystemDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
