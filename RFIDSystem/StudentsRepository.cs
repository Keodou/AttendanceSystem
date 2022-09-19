using RFIDSystem.Data;

namespace RFIDSystem
{
    public class StudentsRepository
    {
        private readonly RFIDSystemDbContext _dbContext;
        //private readonly List<Student> _students;

        public StudentsRepository(RFIDSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*public List<Student> AddStudents()
        {
            _students.Add(new Student() { Id = 1, Name = "Каминский Алексей", RFIDTag = " 99 62 36 BB ", 
                Attendance = "Отсутствует", AttendanceTime = "00.00.00"});
            _students.Add(new Student() { Id = 2, Name = "Коробейщиков Дмитрий", RFIDTag = " B9 8C 2C BB ", 
                Attendance = "Отсутствует", AttendanceTime = "00.00.00"});

            return _students.OrderBy(s => s.Name).ToList();
        }*/

        /*public List<Student> GetStudents()
        {
            return _students.OrderBy(s => s.Name).ToList();
        }*/

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

        public List<Student> GetStudentsDb()
        {
            return _dbContext.Students.OrderBy(s => s.Name).ToList();
        }
    }
}
