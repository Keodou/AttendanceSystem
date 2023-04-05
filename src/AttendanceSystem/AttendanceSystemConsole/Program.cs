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
/*var services = new ServiceCollection()
    .AddDbContext<RFIDSystemDbContext>(options => options
    .UseSqlServer(@"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;"))*/
//.AddScoped<IEntriesRepository, StudentsRepository>();
/*var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);*/
RFIDSystemDbContext dbContext = new();
StudentsRepository studentsRepository = new(dbContext);
/*var serviceProvider = services.BuildServiceProvider();
var dbContext = serviceProvider.GetService<RFIDSystemDbContext>();
var studentsRepository = serviceProvider.GetService<StudentsRepository>();*/
Reader reader = new();
ConsoleManager systemManager = new(reader, studentsRepository);

systemManager.InputVariable();