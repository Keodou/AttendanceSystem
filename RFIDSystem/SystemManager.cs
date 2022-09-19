using RFIDSystem.Data;

namespace RFIDSystem
{
    public class SystemManager
    {
        private string _label;
        private readonly Reader _reader;
        private readonly StudentsRepository _studentsRepository;
        private List<Student> _students;
        private RFIDSystemDbContext _dbContext;

        public SystemManager(string label, Reader reader, StudentsRepository studentsRepository,
            RFIDSystemDbContext dbContext)
        {
            _label = label;
            _reader = reader;
            _studentsRepository = studentsRepository;
            _dbContext = dbContext;
        }

        public void InputMenuVariable(string variable)
        {
            Console.WriteLine("Выберите пункт");
            variable = Console.ReadLine();
            SelectMenuVariable(variable);
        }

        private void SelectMenuVariable(string variable)
        {
            switch (variable)
            {
                case "1":
                    Console.WriteLine("Приложите метку для сканирования");
                    ScanTheLabel();
                    InputMenuVariable(variable);
                    break;
                case "2":
                    Console.WriteLine("Список студентов");
                    _students = _studentsRepository.GetStudentsDb();
                    OutputStudents();
                    InputMenuVariable(variable);
                    break;
                default:
                    Console.WriteLine("Введите корректное значение!");
                    InputMenuVariable(variable);
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
    }
}
