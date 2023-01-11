using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class StudentsRepository : IEntriesRepository
    {
        private readonly RFIDSystemDbContext _dbContext;

        public StudentsRepository(RFIDSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Student> GetEntries()
        {
            return _dbContext.Students.OrderBy(s => s.Name);
        }

        public IQueryable<Student> GetEntries(Group group)
        {
            return _dbContext.Students.Where(g => g.Group == group).OrderBy(s => s.Name);
        }

        public Student? GetEntryByTag(string tag)
        {
            return _dbContext.Students
                .Where(l => l.RfidTag == tag)
                .FirstOrDefault();
        }

        public List<Student> GetEntryByAttendanceRecords(int id)
        {
            return _dbContext.Students.Where(s => s.Id == id).Include(a => a.AttendanceRecords).ToList();
        }

        public void Save(Student? entry)
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

        public void Delete(Student? entry)
        {
            _dbContext.Students.Remove(entry);
            _dbContext.SaveChanges();
        }
    }
}
