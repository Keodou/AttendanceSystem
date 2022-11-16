using DAL;
using DAL.Data;
using RfidReader;
using AttendanceSystemConsole;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;

// Initial objects
//IConfiguration? configuration = new Config;
var services = new ServiceCollection()
    .AddSingleton<IConfiguration>()
    .AddDbContext<DbContext>();
RFIDSystemDbContext dbContext = new();
StudentsRepository studentRepository = new(dbContext);
Reader reader = new();
ConsoleManager systemManager = new(reader, studentRepository);

systemManager.InputVariable();