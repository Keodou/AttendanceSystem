using RFIDSystem;
using RFIDSystem.Data;
using System.IO.Ports;

// Initial objects
string label = "";
string connectionString = @"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;";
RFIDSystemDbContext dbContext = new(connectionString);
SerialPort RFID = new();
StudentsRepository studentRepository = new(dbContext);
Reader reader = new(RFID);
SystemManager systemManager = new(label, reader, studentRepository);
//studentRepository.AddStudentsDb();
systemManager.InputVariable();