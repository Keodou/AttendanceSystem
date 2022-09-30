using RFIDSystem;
using RFIDSystem.Data;
using System.IO.Ports;

// Initial objects
string connectionString = @"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;";
RFIDSystemDbContext dbContext = new(connectionString);
SerialPort rfid = new();
StudentsRepository studentRepository = new(dbContext);
Reader reader = new(rfid);
SystemManager systemManager = new(reader, studentRepository);

systemManager.InputVariable();