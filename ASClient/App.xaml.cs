using DAL;
using DAL.Data;
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
        private readonly ServiceProvider _serviceProvider;
        private IConfiguration _configuration;
        private readonly string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=RFIDSystem;Trusted_Connection=True;";

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
            var connectionString = _configuration.GetConnectionString("ServerConnection");
            var services = new ServiceCollection()
                .AddDbContext<RFIDSystemDbContext>(options =>
                {
                    options.UseSqlServer(connectionString, builder =>
                    {
                        builder.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5), 
                            errorNumbersToAdd: null);
                    });
                    //options.UseSqlServer(_connectionString);
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                })
                .AddScoped<StudentsRepository>()
                .AddSingleton<MainWindow>();
            _serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
