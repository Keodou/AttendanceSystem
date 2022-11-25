using DAL;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ASClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection()
                .AddDbContext<RFIDSystemDbContext>(options =>
                {
                    options.UseSqlServer(@"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;");
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
