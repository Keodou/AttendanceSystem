using DAL;
using DAL.Data;
using DAL.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace ASClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider ServiceProvider { get; set; }
        public IConfiguration Configuration { get; set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
            var connectionString = Configuration.GetConnectionString("ServerConnection");
            var services = new ServiceCollection()
                .AddDbContext<RFIDSystemDbContext>(options =>
                {
                    options.UseSqlServer(connectionString, builder =>
                    {
                        builder.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5),
                            errorNumbersToAdd: null);
                    });
                    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                })
                .AddScoped<UsersRepository>()
                .AddScoped<GroupsRepository>()
                .AddScoped<StudentsRepository>()
                .AddScoped<AttendanceRecordsRepository>()
                .AddTransient<AuthorizationWindow>()
                .AddSingleton<MainWindow>();
            ServiceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var authorizationWindow = ServiceProvider.GetService<AuthorizationWindow>();
            authorizationWindow.Show();
        }
    }
}
