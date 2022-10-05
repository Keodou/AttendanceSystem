using DAL.Entities;
using DAL.Interfaces;

namespace RFIDSystem
{
    public class ConsoleManager
    {
        private readonly string _tag;
        private readonly Reader _reader;
        private readonly IEntriesRepository _studentsRepository;

        public ConsoleManager(Reader reader, IEntriesRepository studentsRepository)
        {
            _tag = "";
            _reader = reader;
            _studentsRepository = studentsRepository;
        }

        public void InputVariable()
        {
            Console.WriteLine("Выберите пункт");
            var variable = Console.ReadLine();
            SelectMenuVariable(variable);
        }

        // TODO: Рассмотреть альтернативные способы создания меню
        private void SelectMenuVariable(string variable)
        {
            switch (variable)
            {
                case "/scan":
                    Console.WriteLine("Приложите метку для сканирования");
                    ScanTheLabel();
                    InputVariable();
                    break;
                case "/list":
                    Console.WriteLine("Список студентов");
                    OutputStudents();
                    InputVariable();
                    break;
                case "/create":
                    EditEntry();
                    break;
                default:
                    Console.WriteLine("Введите корректное значение!");
                    InputVariable();
                    break;
            }
        }

        private void ScanTheLabel()
        {
            var tag = _reader.GetRfidTag(_tag);
            Console.WriteLine(_tag);
            _studentsRepository.UpdateAttendance(tag);
        }

        // TODO: Сделать операции с БД асинхронными
        private void OutputStudents()
        {
            var students = _studentsRepository.GetEntriesDb();
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}\nAttendance: {student.Attendance}" +
                    $"\nAttendanceTime: {student.AttendanceTime}");
                Console.WriteLine();
            }
        }

        private void EditEntry()
        {
            var student = new Student()
            {
                Name = Console.ReadLine(),
                RFIDTag = Console.ReadLine(),
                Attendance = Console.ReadLine(),
                AttendanceTime = Console.ReadLine()
            };
            _studentsRepository.SaveChanges(student);
        }
    }
}
