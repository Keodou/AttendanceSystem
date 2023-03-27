using DAL.Models.Repositories;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ASClient.Views
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private readonly AttendanceRecordsRepository _recordsRepository;

        public HistoryWindow(AttendanceRecordsRepository recordsRepository)
        {
            InitializeComponent();
            _recordsRepository = recordsRepository;
            EntriesList.ItemsSource = _recordsRepository.GetAttendanceRecords();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
