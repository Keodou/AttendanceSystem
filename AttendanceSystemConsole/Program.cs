using DAL;
using DAL.Data;
using RfidReader;
using AttendanceSystemConsole;

// Initial objects
RFIDSystemDbContext dbContext = new();
StudentsRepository studentRepository = new(dbContext);
Reader reader = new();
ConsoleManager systemManager = new(reader, studentRepository);

systemManager.InputVariable();