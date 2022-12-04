using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DAL.Data
{
    public class RFIDSystemDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public RFIDSystemDbContext(DbContextOptions<RFIDSystemDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
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
