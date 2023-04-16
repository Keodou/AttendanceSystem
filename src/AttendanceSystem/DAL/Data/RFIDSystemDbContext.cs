using DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class RFIDSystemDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        public RFIDSystemDbContext(DbContextOptions<RFIDSystemDbContext> options) : base(options)
        {

        }

        public RFIDSystemDbContext() 
        {

        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connecя искалtion=True;");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }*/
    }
}
