using DAL;
using DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .DistinctBy(l => l.Pair)
                .OrderBy(l => l.Pair).ToList();
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
                .DistinctBy(l => l.Pair)
                .OrderBy(l => l.Pair)
                .ToList();
            HistoryList.ItemsSource = list;
        }
    }
}
