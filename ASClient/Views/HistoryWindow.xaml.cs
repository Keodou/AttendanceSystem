using DAL.Models.Entities;
using DAL.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace ASClient.Views
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        private readonly AttendanceRecordsRepository _recordsRepository;

        public HistoryWindow(AttendanceRecordsRepository recordsRepository, GroupsRepository groupsRepository)
        {
            InitializeComponent();
            _recordsRepository = recordsRepository;
            GroupsList.ItemsSource = groupsRepository.GetGroups().ToList();
            EntriesList.ItemsSource = _recordsRepository.GetAttendanceRecords();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GroupsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            EntriesList.ItemsSource = _recordsRepository.GetAttendanceRecords(GroupsList.SelectedItem as Group);
        }

        private void DatesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DateTime date = Convert.ToDateTime(DatesList.SelectedDate);
            UpdateRecords(date);
        }

        private void UpdateRecords(DateTime date)
        {
            List<AttendanceRecord> list = _recordsRepository.GetAttendanceRecords();
            if (GroupsList.SelectedIndex > 0)
            {
                list = _recordsRepository.GetAttendanceRecords(GroupsList.SelectedItem as Group, date)
                    .DistinctBy(a => a.Student.Name).ToList();
            }
            else
            {
                list = _recordsRepository.GetAttendanceRecords(date);
            }
            EntriesList.ItemsSource = list;
        }
    }
}
