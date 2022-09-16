using RFIDSystem;
using System.IO.Ports;

// Initial objects
string label = "";
SerialPort RFID = new();
List<Student> students = new();
// DateTime attendanceTime = new(0, 0, 0);
StudentsRepository studentRepository = new(students);
Reader reader = new(RFID);
SystemManager systemManager = new(label, reader, studentRepository, students);

// Заполнение коллекции
students = studentRepository.AddStudents();

Console.WriteLine("Выберите пункт");
string variable = Console.ReadLine();
systemManager.SelectMenuVariable(variable);