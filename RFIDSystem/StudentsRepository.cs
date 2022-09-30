using RFIDSystem.Data;
using RFIDSystem.Interfaces;

namespace RFIDSystem
{
    public class StudentsRepository : IEntriesRepository
    {
        private readonly RFIDSystemDbContext _dbContext;

        public StudentsRepository(RFIDSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStudentsDb()
        {
            _dbContext.Students.Add(new Student()
            {
                Name = "Каминский Алексей",
                RFIDTag = " 99 62 36 BB ",
                Attendance = "Отсутствует",
                AttendanceTime = "00.00.00"
            });

            _dbContext.SaveChanges();
        }

        public void UpdateAttendance(string tag)
        {
            var student = _dbContext.Students
                .Where(l => l.RFIDTag == tag)
                .FirstOrDefault();
            if (student != null)
            {
                student.Attendance = "Присутствует";
                student.AttendanceTime = DateTime.Now.ToString();
            }

            _dbContext.SaveChanges();
        }

        public void SaveChanges(Student student)
        {
            _dbContext.Add(student);
            _dbContext.SaveChanges();
        }

        public IQueryable<Student> GetEntriesDb()
        {
            return _dbContext.Students.OrderBy(s => s.Name);
        }
    }
}
