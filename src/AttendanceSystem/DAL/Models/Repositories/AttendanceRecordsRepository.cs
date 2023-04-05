using DAL.Data;
using DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

        public List<AttendanceRecord> GetAttendanceRecords(Group group)
        {
            return _dbContext.AttendanceRecords
                .Include(a => a.Student)
                .Where(a => a.Student.Group == group)
                .ToList();
        }

        public List<AttendanceRecord> GetAttendanceRecords(Group group, DateTime date)
        {
            return _dbContext.AttendanceRecords
                .Include(a => a.Student)
                .Where(a => a.Student.Group == group && a.AttendanceDate == date)
                .ToList();
        }

        public List<AttendanceRecord> GetAttendanceRecords(DateTime date)
        {
            return _dbContext.AttendanceRecords
                .Include(a => a.Student)
                .Where(a => a.AttendanceDate == date)
                .ToList();
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
