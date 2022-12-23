using DAL.Data;
using DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models.Repositories
{
    public class AttendanceRecordsRepository
    {
        private readonly RFIDSystemDbContext _dbContext;

        public AttendanceRecordsRepository(RFIDSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(AttendanceRecord? entry)
        {
            if (entry.Id == default)
            {
                _dbContext.Add(entry);
            }
            else
            {
                _dbContext.Update(entry);
            }
            _dbContext.SaveChanges();
            _dbContext.Entry(entry).State = EntityState.Detached;
        }
    }
}
