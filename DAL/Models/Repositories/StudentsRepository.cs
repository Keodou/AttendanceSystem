using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;

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
            return _dbContext.Students.OrderBy(s => s.Id);
        }

        public Student? GetEntryByTag(string tag)
        {
            return _dbContext.Students
                .Where(l => l.RfidTag == tag)
                .FirstOrDefault();
        }

        public void SaveChanges(Student? entry)
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
        }

        public void Delete(Student? entry)
        {
            _dbContext.Students.Remove(entry);
            _dbContext.SaveChanges();
        }
    }
}
