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

        public List<AttendanceRecord> GetAttendanceRecords()
        {
            return _dbContext.AttendanceRecords.Include(a => a.Student).ToList();
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
