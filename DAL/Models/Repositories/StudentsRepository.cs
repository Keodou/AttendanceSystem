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

        public Student? GetEntry(string tag)
        {
            return _dbContext.Students
                .Where(l => l.RfidTag == tag)
                .FirstOrDefault();
            /*if (student != null)
            {
                student.Attendance = "Присутствует";
                student.AttendanceTime = DateTime.Now.ToString();
            }
            _dbContext.SaveChanges();*/
        }

        public void SaveChanges(Student entry)
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

        public IQueryable<Student> GetEntries()
        {
            return _dbContext.Students.OrderBy(s => s.Id);
        }

        /*public Student GetEntriesById(int number)
        {
            return _dbContext.Students.Single(x => x.Id == number);
        }*/
    }
}
