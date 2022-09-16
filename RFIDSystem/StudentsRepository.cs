using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RFIDSystem
{
    public class StudentsRepository
    {
        private readonly List<Student> _students;

        public StudentsRepository(List<Student> students)
        {
            _students = students;
        }

        public List<Student> AddStudents()
        {
            _students.Add(new Student() { Id = 1, Name = "Каминский Алексей", RFIDTag = " 99 62 36 BB ", 
                Attendance = "Отсутствует", AttendanceTime = "00.00.00"});
            _students.Add(new Student() { Id = 2, Name = "Коробейщиков Дмитрий", RFIDTag = " B9 8C 2C BB ", 
                Attendance = "Отсутствует", AttendanceTime = "00.00.00"});

            return _students.OrderBy(p => p.Name).ToList();
        }

        public List<Student> GetStudents()
        {
            return _students.OrderBy(p => p.Name).ToList();
        }
    }
}
