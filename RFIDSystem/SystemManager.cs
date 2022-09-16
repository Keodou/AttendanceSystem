using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDSystem
{
    public class SystemManager
    {
        private string _label;
        private readonly Reader _reader;
        private readonly StudentsRepository _studentsRepository;
        private List<Student> _students;

        public SystemManager(string label, Reader reader, StudentsRepository studentsRepository,
            List<Student> students)
        {
            _label = label;
            _reader = reader;
            _studentsRepository = studentsRepository;
            _students = students;
        }

        public void SelectMenuVariable(string variable)
        {
            switch (variable)
            {
                case "":
                    Console.WriteLine("Вы ничего не ввели! Введите значение");
                    Repeat(variable);
                    break;
                case "1":
                    Console.WriteLine("Приложите метку для сканирования");
                    ScanTheLabel();
                    Repeat(variable);
                    break;
                case "2":
                    Console.WriteLine("Список студентов");
                    _students = _studentsRepository.GetStudents();
                    OutputStudents();
                    Repeat(variable);
                    break;
                default:
                    Console.WriteLine("Такой вариант отсутствует!");
                    Repeat(variable);
                    break;
            }
        }

        private void ScanTheLabel()
        {
            _label = _reader.GetCardId(_label);
            Console.WriteLine(_label);
            foreach (var student in _students)
            {
                if (_label == student.RFIDTag)
                {
                    student.Attendance = "Присутствует";
                    student.AttendanceTime = DateTime.Now.ToString();
                }
            }
        }

        private void OutputStudents()
        {
            foreach (var student in _students)
            {
                Console.WriteLine($"Name: {student.Name}\nAttendance: {student.Attendance}" +
                    $"\nAttendanceTime: {student.AttendanceTime}");
                Console.WriteLine();
            }
        }

        private void Repeat(string variable)
        {
            Console.WriteLine("Выберите пункт");
            variable = Console.ReadLine();
            SelectMenuVariable(variable);
        }
    }
}
