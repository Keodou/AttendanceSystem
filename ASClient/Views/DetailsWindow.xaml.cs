using DAL;
using DAL.Entities;
using DAL.Models.Entities;
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
    /// Логика взаимодействия для DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private List<AttendanceRecord> _attendanceRecords;

        public DetailsWindow(Student student, StudentsRepository studentsRepository)
        {
            InitializeComponent();
            _attendanceRecords = student.AttendanceRecords;
            HistoryList.ItemsSource = _attendanceRecords;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DatesList_Loaded(object sender, RoutedEventArgs e)
        {
            var records = _attendanceRecords.AsEnumerable().DistinctBy(r => r.AttendanceTime).ToList();
            foreach (var record in records)
            {
                DatesList.Items.Add(record.AttendanceTime);
            }
        }

        private void DatesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateRecords();
        }

        private void UpdateRecords()
        {
            DateTime date = default;
            date = Convert.ToDateTime(DatesList.SelectedItem);
            var list = _attendanceRecords.Where(l => l.AttendanceTime == date);
            HistoryList.ItemsSource = list;
        }
    }
}
