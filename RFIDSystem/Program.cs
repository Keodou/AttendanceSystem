using RFIDSystem;
using RFIDSystem.Data;
using System.IO.Ports;

// Initial objects
string label = "";
string variable = "";
string connectionString = @"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;";
RFIDSystemDbContext dbContext = new(connectionString);
SerialPort RFID = new();
// List<Student> students = new();
StudentsRepository studentRepository = new(dbContext);
Reader reader = new(RFID);
SystemManager systemManager = new(label, reader, studentRepository, dbContext);

// Заполнение коллекции
// students = studentRepository.AddStudents();

/*var student1 = new Student()
{
    Name = "Коробейщиков Дмитрий",
    RFIDTag = " B9 8C 2C BB ",
    Attendance = "Отсутствует",
    AttendanceTime = "00.00.00"
};

dbContext.Students.Add(student1);
dbContext.SaveChanges();*/

//studentRepository.AddStudentsDb();

systemManager.InputMenuVariable(variable);