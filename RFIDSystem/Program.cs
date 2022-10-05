using RFIDSystem;
using DAL;
using System.IO.Ports;
using DAL.Data;

// Initial objects
string connectionString = @"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;";
RFIDSystemDbContext dbContext = new(connectionString);
SerialPort rfid = new();
StudentsRepository studentRepository = new(dbContext);
Reader reader = new(rfid);
ConsoleManager systemManager = new(reader, studentRepository);

systemManager.InputVariable();