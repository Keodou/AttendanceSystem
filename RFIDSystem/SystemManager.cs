using RFIDSystem.Interfaces;

namespace RFIDSystem
{
    public class SystemManager
    {
        private string _label;
        private readonly Reader _reader;
        private readonly IEntriesRepository _studentsRepository;

        public SystemManager(string label, Reader reader, IEntriesRepository studentsRepository)
        {
            _label = label;
            _reader = reader;
            _studentsRepository = studentsRepository;
        }

        public void InputVariable()
        {
            Console.WriteLine("Выберите пункт");
            var variable = Console.ReadLine();
            SelectMenuVariable(variable);
        }

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
                    break;
                default:
                    Console.WriteLine("Введите корректное значение!");
                    InputVariable();
                    break;
            }
        }

        private void ScanTheLabel()
        {
            _label = _reader.GetCardId(_label);
            Console.WriteLine(_label);
            _studentsRepository.UpdateEntryDb(_label);
        }

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
    }
}
