using DAL;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string _connectionString;
        private readonly RFIDSystemDbContext _rfidSystemDbContext;
        private readonly StudentsRepository _studentsRepository;

        public MainWindow()
        {
            InitializeComponent();
            _connectionString = @"Server=DMITRYPC;Database=RFIDSystem;Trusted_Connection=True;";
            _rfidSystemDbContext = new(_connectionString);
            _studentsRepository = new(_rfidSystemDbContext);
        }

        private void StudentsList_Loaded(object sender, RoutedEventArgs e)
        {
            var list = _studentsRepository.GetEntriesDb().ToList();
            StudentsList.ItemsSource = list;
        }
    }
}
