using DAL;
using DAL.Models.Entities;
using System.Windows;
using System.Windows.Controls;

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
            HistoryList.ItemsSource = _attendanceRecords
                .GroupBy(a => new { a.AttendanceDate, a.Pair })
                .Select(g => g.First())
                .OrderBy(l => l.AttendanceTime).ToList();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DatesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(DatesList.SelectedDate);
            UpdateRecords(date);
        }

        private void UpdateRecords(DateTime date)
        {
            var list = _attendanceRecords.Where(l => l.AttendanceDate == date)
                .GroupBy(a => new { a.Pair })
                .Select(g => g.First())
                .ToList();
            HistoryList.ItemsSource = list;
        }
    }
}
